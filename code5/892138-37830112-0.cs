    using System;
    using System.Net.Sockets;
    using System.Text;
    
    namespace IT100TestDriver
    {
        class Program
        {
            static void Main(string[] args)
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var address = System.Net.IPAddress.Parse("192.168.1.250");
                System.Net.EndPoint ep = new System.Net.IPEndPoint(address, 1024);
                s.Connect(ep);
                byte[] buffer = new byte[1024];
    
                NetworkStream ns = new NetworkStream(s);
    
                AsyncCallback callback = null;
                callback = ar =>
                {
                    int bytesRead = ns.EndRead(ar);
                    string fromIT100 = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.Write(fromIT100);
                    ns.BeginRead(buffer, 0, 1024, callback, null);
                };
    
                Console.WriteLine("Connected to: {0}", ep.ToString());
                ns.BeginRead(buffer, 0, 1024, callback, null);
    
                while (true)
                {
                    var ki = Console.ReadKey(true);
                    byte[] command = null;                
                    switch (ki.KeyChar)
                    {
                        case 'p':
                            {
                                Console.WriteLine("Sending Ping");
                                command = Encoding.ASCII.GetBytes("000"); // ping
                            }
                            break;
                        case 's':
                            {
                                Console.WriteLine("Sending Status Request");
                                command = Encoding.ASCII.GetBytes("001"); // status request
                            }
                            break;
                    }
    
                    if (command != null)
                    {
                        byte[] crlf = { 0x0D, 0x0A };
                        ns.Write(command, 0, command.Length);
                        byte[] checksum = calculateChecksum(command);
                        ns.Write(checksum, 0, checksum.Length);
                        ns.Write(crlf, 0, crlf.Length);
                    }
                }
            }
            private static byte[] calculateChecksum(byte[] dataToSend)
            {
                int sum = 0;
                foreach(byte b in dataToSend)
                {
                    sum += b;
                }
    
                int truncatedto8Bits = sum & 0x000000FF;
                byte upperNibble = (byte)(((byte)(truncatedto8Bits & 0x000000F0)) >> 4);
                byte lowerNibble = (byte) (truncatedto8Bits & 0x0000000F);
    
                // value is 0x09, need to treat it as '9' and convert to ASCII (0x39)
    
                byte upperNibbleAsAscii = (byte)nibbleToAscii(upperNibble);
                byte lowerNibbleAsAscii = (byte)nibbleToAscii(lowerNibble);
                return new byte[] { upperNibbleAsAscii, lowerNibbleAsAscii };
            }
    
            private static char nibbleToAscii(byte b)
            {            
                switch (b)
                {
                    case 0x00: return '0';
                    case 0x01: return '1';
                    case 0x02: return '2';
                    case 0x03: return '3';
                    case 0x04: return '4';
                    case 0x05: return '5';
                    case 0x06: return '6';
                    case 0x07: return '7';
                    case 0x08: return '8';
                    case 0x09: return '9';
                    case 0x0A: return 'A';
                    case 0x0B: return 'B';
                    case 0x0C: return 'C';
                    case 0x0D: return 'D';
                    case 0x0E: return 'E';
                    case 0x0F: return 'F';
                    default:
                        throw new ArgumentOutOfRangeException("Unknown Nibble");
                }
            }
        }   
    }
