    using System;
    using System.Collections.Generic;
    using PcapDotNet.Core;
    using PcapDotNet.Packets;
    using PcapDotNet.Packets.Ethernet;
    using PcapDotNet.Packets.Http;
    using PcapDotNet.Packets.IpV4;
    using PcapDotNet.Packets.Transport;
    
    namespace SendingHttpGet
    {
        internal class HttpGetSender
        {
            public HttpGetSender()
            {
            }
    
            public MacAddress SourceMac { get; set; }
            public MacAddress DestinationMac { get; set; }
            public IpV4Address SourceIpV4 { get; set; }
            public IpV4Address DestinationIpV4 { get; set; }
            public string Host { get; set; }
    
            public void Run(PacketDevice device)
            {
                using (PacketCommunicator communicator = device.Open(100, // name of the device
                                                                     PacketDeviceOpenAttributes.Promiscuous,
                                                                     // promiscuous mode
                                                                     100)) // read timeout
                {
                    SendSyn(communicator);
                    WaitForAck(communicator);
                }
            }
    
            private void WaitForAck(PacketCommunicator communicator)
            {
                communicator.SetFilter("tcp and src " + DestinationIpV4 + " and dst " + SourceIpV4 + " and src port " + _destinationPort + " and dst port " + _sourcePort);
                Packet packet;
                while (true)
                {
                    if (communicator.ReceivePacket(out packet) == PacketCommunicatorReceiveResult.Ok)
                    {
                        if (packet.Ethernet.IpV4.Tcp.AcknowledgmentNumber == _expectedAckNumber)
                        {
                            _seqNumber = _expectedAckNumber;
                            _ackNumber = packet.Ethernet.IpV4.Tcp.SequenceNumber + 1;
                            SendGet(communicator);
                            break;
                        }
    
                    }
                    SendSyn(communicator);
                }
                WaitForResponse(communicator);
            }
    
            private void WaitForResponse(PacketCommunicator communicator)
            {
                communicator.SetFilter("tcp and src " + DestinationIpV4 + " and dst " + SourceIpV4 + " and src port " + _destinationPort + " and dst port " + _sourcePort);
                Packet packet;
                while (true)
                {
                    if (communicator.ReceivePacket(out packet) == PacketCommunicatorReceiveResult.Ok)
                    {
                        Console.WriteLine("Expected ack number: " + _expectedAckNumber);
                        Console.WriteLine("Received ack number: " + packet.Ethernet.IpV4.Tcp.AcknowledgmentNumber);
                        if (packet.Ethernet.IpV4.Tcp.AcknowledgmentNumber == _expectedAckNumber)
                        {
                            break;
                        }
    
                    }
                    SendGet(communicator);
                }
            }
    
            private void SendSyn(PacketCommunicator communicator)
            {
                // Ethernet Layer
                EthernetLayer ethernetLayer = new EthernetLayer
                                                  {
                                                      Source = SourceMac,
                                                      Destination = DestinationMac,
                                                  };
    
                // IPv4 Layer
                IpV4Layer ipV4Layer = new IpV4Layer
                                          {
                                              Source = SourceIpV4,
                                              CurrentDestination = DestinationIpV4,
                                              Ttl = 128,
                                              Fragmentation =
                                                  new IpV4Fragmentation(IpV4FragmentationOptions.DoNotFragment, 0),
                                              Identification = 1234,
                                          };
    
                // TCP Layer
                TcpLayer tcpLayer = new TcpLayer
                                        {
                                            SourcePort = _sourcePort,
                                            DestinationPort = _destinationPort,
                                            SequenceNumber = _seqNumber,
                                            ControlBits = TcpControlBits.Synchronize,
                                            Window = _windowSize,
                                        };
    
                communicator.SendPacket(PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, tcpLayer));
                _expectedAckNumber = _seqNumber + 1;
            }
    
            private void SendGet(PacketCommunicator communicator)
            {
                // Ethernet Layer
                EthernetLayer ethernetLayer = new EthernetLayer
                {
                    Source = SourceMac,
                    Destination = DestinationMac,
                };
    
                // IPv4 Layer
                IpV4Layer ipV4Layer = new IpV4Layer
                {
                    Source = SourceIpV4,
                    CurrentDestination = DestinationIpV4,
                    Ttl = 128,
                    Fragmentation =
                        new IpV4Fragmentation(IpV4FragmentationOptions.DoNotFragment, 0),
                    Identification = 1235,
                };
    
                // TCP Layer
                TcpLayer tcpLayer = new TcpLayer
                {
                    SourcePort = _sourcePort,
                    DestinationPort = _destinationPort,
                    SequenceNumber = _seqNumber,
                    AcknowledgmentNumber = _ackNumber,
                    ControlBits = TcpControlBits.Acknowledgment,
                    Window = _windowSize,
                };
    
                // HTTP Layer
                HttpLayer httpLayer = new HttpRequestLayer
                {
                    Uri = "/",
                    Header = new HttpHeader(HttpField.CreateField("Host", Host)),
                    Method = new HttpRequestMethod(HttpRequestKnownMethod.Get),
                    Version = HttpVersion.Version11,
                };
    
                Packet packet = PacketBuilder.Build(DateTime.Now, ethernetLayer, ipV4Layer, tcpLayer, httpLayer);
                communicator.SendPacket(packet);
                _expectedAckNumber = (uint) (_seqNumber + packet.Ethernet.IpV4.Tcp.PayloadLength);
            }
    
            private ushort _sourcePort = (ushort) (4123 + new Random().Next() % 1000);
            private ushort _destinationPort = 80;
            private uint _seqNumber = (uint) new Random().Next();
            private uint _expectedAckNumber;
            private ushort _windowSize = 8192;
            private uint _ackNumber;
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                // Retrieve the device list from the local machine
                IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
    
                if (allDevices.Count == 0)
                {
                    Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                    return;
                }
    
                // Print the list
                for (int i = 0; i != allDevices.Count; ++i)
                {
                    LivePacketDevice device = allDevices[i];
                    Console.Write((i + 1) + ". " + device.Name);
                    if (device.Description != null)
                        Console.WriteLine(" (" + device.Description + ")");
                    else
                        Console.WriteLine(" (No description available)");
                }
    
                int deviceIndex = 0;
                do
                {
                    Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
                    string deviceIndexString = Console.ReadLine();
                    if (!int.TryParse(deviceIndexString, out deviceIndex) ||
                        deviceIndex < 1 || deviceIndex > allDevices.Count)
                    {
                        deviceIndex = 0;
                    }
                } while (deviceIndex == 0);
    
                // Take the selected adapter
                PacketDevice selectedDevice = allDevices[deviceIndex - 1];
    
                HttpGetSender sender = new HttpGetSender
                                           {
                                               SourceMac = new MacAddress("your:host:mac:address:1:2"),
                                               DestinationMac = new MacAddress("gateway:mac:address:1:2:3"),
                                               SourceIpV4 = new IpV4Address("your.host.ip.address"),
                                               DestinationIpV4 = new IpV4Address("target.host.ip.address"),
                                               Host = "targethost.com",
                                           };
    
                sender.Run(selectedDevice);
            }
        }
    }
