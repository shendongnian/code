    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    namespace tcpsocks5
    {
      static class Program
      {
        static void ReadAll(this NetworkStream stream, byte[] buffer, int offset, int size)
        {
          while (size != 0) {
            var read = stream.Read(buffer, offset, size);
            if (read < 0) {
              throw new IOException("Premature end");
            }
            size -= read;
            offset += read;
          }
        }
        static void Main(string[] args)
        {
          using (var client = new TcpClient()) {
            client.Connect(ip, port); // Provide IP, Port yourself
            using (var stream = client.GetStream()) {
              // Auth
              var buf = new byte[300];
              buf[0] = 0x05; // Version
              buf[1] = 0x01; // NMETHODS
              buf[2] = 0x00; // No auth-method
              stream.Write(buf, 0, 3);
    
              stream.ReadAll(buf, 0, 2);
              if (buf[0] != 0x05) {
                throw new IOException("Invalid Socks Version");
              }
              if (buf[1] == 0xff) {
                throw new IOException("Socks Server does not support no-auth");
              }
              if (buf[1] != 0x00) {
                throw new Exception("Socks Server did choose bogus auth");
              }
    
              // Request
              buf[0] = 0x05; // Version
              buf[1] = 0x01; // Connect (TCP)
              buf[2] = 0x00; // Reserved
              buf[3] = 0x03; // Dest.Addr: Domain name
              var domain = Encoding.ASCII.GetBytes("google.com");
              buf[4] = (byte)domain.Length; // Domain name length (octet)
              Array.Copy(domain, 0, buf, 5, domain.Length);
              var port = BitConverter.GetBytes(
                IPAddress.HostToNetworkOrder((short)80));
              buf[5 + domain.Length] = port[0];
              buf[6 + domain.Length] = port[1];
              stream.Write(buf, 0, domain.Length + 7);
    
              // Reply
              stream.ReadAll(buf, 0, 4);
              if (buf[0] != 0x05) {
                throw new IOException("Invalid Socks Version");
              }
              if (buf[1] != 0x00) {
                throw new IOException(string.Format("Socks Error {0:X}", buf[1]));
              }
              var rdest = string.Empty;
              switch (buf[3]) {
                case 0x01: // IPv4
                  stream.ReadAll(buf, 0, 4);
                  var v4 = BitConverter.ToUInt32(buf, 0);
                  rdest = new IPAddress(v4).ToString();
                  break;
                case 0x03: // Domain name
                  stream.ReadAll(buf, 0, 1);
                  if (buf[0] == 0xff) {
                    throw new IOException("Invalid Domain Name");
                  }
                  stream.ReadAll(buf, 1, buf[0]);
                  rdest = Encoding.ASCII.GetString(buf, 1, buf[0]);
                  break;
                case 0x04: // IPv6
                  var octets = new byte[16];
                  stream.ReadAll(octets, 0, 16);
                  rdest = new IPAddress(octets).ToString();
                  break;
                default:
                  throw new IOException("Invalid Address type");
              }
              stream.ReadAll(buf, 0, 2);
              var rport = (ushort)IPAddress.NetworkToHostOrder((short)BitConverter.ToUInt16(buf, 0));
              Console.WriteLine("Connected via {0}:{1}", rdest, rport);
    
              // Make an HTTP request, aka. "do stuff ..."
              using (var writer = new StreamWriter(stream)) {
                writer.Write("GET / HTTP/1.1\r\nHost: google.com\r\n\r\n");
                writer.Flush();
                using (var reader = new StreamReader(stream)) {
                  while (true) {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line)) {
                      break;
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
