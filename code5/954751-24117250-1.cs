    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          StartServer();
          // test sending
          Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          client.Connect(IPAddress.Parse("127.0.0.1"), 4000);
          // get a file here instead
          byte[] longBuffer = new byte[3824726];
          byte[] buffer = new byte[4096];
          // emulated stream over emulated buffer
          using (var stream = new MemoryStream(longBuffer, false)) {
            while (true) {
              int read = stream.Read(buffer, 0, buffer.Length);
              if (read <= 0) {
                break;
              }
              for (int sendBytes = 0; sendBytes < read; sendBytes += client.Send(buffer, sendBytes, read - sendBytes, SocketFlags.None)) {
              }
            }
          }
          // the tricky part ;)
          client.Close();
          Console.In.ReadLine();
          _stop = true;
        }
        private static TcpListener _listener;
        private static volatile bool _stop = false;
        private sealed class Client : IDisposable {
          public Socket Socket { get; private set; }
          public byte[] Buffer { get; private set; }
          public FileStream WriteStream { get; private set; }
          public Client(Socket socket) {
            if (socket == null) {
              throw new ArgumentNullException("socket");
            }
            Socket = socket;
            Buffer = new byte[4096];
            WriteStream = File.OpenWrite(@"c:\foo" + Guid.NewGuid().ToString("N") + ".txt");
          }
          public void Close() {
            if (Socket != null) {
              Socket.Close();
            }
            if (WriteStream != null) {
              WriteStream.Close();
            }
          }
          public void Dispose() {
            Close();
          }
        }
        public static void StartServer() {
          IPAddress localIPAddress = IPAddress.Parse("127.0.0.1");
          IPEndPoint ipLocal = new IPEndPoint(localIPAddress, 4000);
          _listener = new TcpListener(ipLocal);
          _listener.Start();
          _listener.BeginAcceptSocket(BeginAcceptSocketCallback, null);
        }
        private static void BeginAcceptSocketCallback(IAsyncResult asyn) {
          Client client = null;
          try {
            client = new Client(_listener.EndAcceptSocket(asyn));
            client.Socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, BeginReceiveCallback, client);
          } catch (ObjectDisposedException e) {
            HandleSocketFailure(client, e, "BeginAcceptSocketCallback failure", false);
          } catch (SocketException e) {
            HandleSocketFailure(client, e, "BeginAcceptSocketCallback failure", false);
          } catch (Exception e) {
            HandleSocketFailure(client, e, "BeginAcceptSocketCallback failure", true);
          }
          if (!_stop) {
            _listener.BeginAcceptSocket(BeginAcceptSocketCallback, null);
          }
        }
        private static void BeginReceiveCallback(IAsyncResult result) {
          var client = (Client)result.AsyncState;
          try {
            int bytesRead = client.Socket.EndReceive(result);
            if (bytesRead > 0) {
              client.WriteStream.Write(client.Buffer, 0, bytesRead);
              client.Socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, BeginReceiveCallback, client);
            } else {
              client.Close();
            }
          } catch (SocketException e) {
            HandleSocketFailure(client, e, "BeginReceiveCallback failure", false);
          } catch (ObjectDisposedException e) {
            HandleSocketFailure(client, e, "BeginReceiveCallback failure", false);
          } catch (Exception e) {
            HandleSocketFailure(client, e, "BeginReceiveCallback failure", true);
          }
        }
        private static void HandleSocketFailure(Client client, Exception exception, string message, bool isFatal) {
          // log exception as well at least for isFatal = true
          if (client != null) {
            client.Close();
          }
        }
      }
    }
