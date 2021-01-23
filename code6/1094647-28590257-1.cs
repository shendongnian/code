        using System;
        using System.Net;
        using System.Net.Sockets;
        using System.Text;
        using System.Threading;
        namespace Test42
        {
            internal static class Program
            {
                private static int PORT = 1337;
                private static void Main()
                {
                    bool ok;
            
                    // Try to build a mutex.
                    var mutex = new Mutex(true, @"Test42", out ok);
                    // If build is ok, we run as a server. 
                    // Otherwise, the server is already running, so we run as a client.
                    if (ok)
                    {
                        var server = new MyServer(PORT);
                        server.Start();
                    }
                    else
                    {
                        var r = new Random();
                        var message = "Ho Hey : " + r.Next(50);
                        var client = new MyClient();
                        client.Send(PORT, message);
                    }
                }
            }
            internal class MyClient
            {
                /// <summary>
                /// Send a message to localhost.
                /// </summary>
                /// <param name="port">The port to connect.</param>
                /// <param name="message">The message to send.</param>
                public void Send(int port, string message)
                {
                    var client = new TcpClient();
                    var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                    client.Connect(serverEndPoint);
                    using (var stream = client.GetStream())
                    {
                        var messageBuffer = Encoding.Unicode.GetBytes(message);
                        var lengthBuffer = BitConverter.GetBytes(messageBuffer.Length);
                        // Send message length.
                        stream.Write(lengthBuffer, 0, lengthBuffer.Length);
                        // Send message.
                        stream.Write(messageBuffer, 0, messageBuffer.Length);
                        stream.Flush();
                    }
                    client.Close();
                }
            }
            internal class MyServer
            {
                private readonly int _port;
                public MyServer(int port)
                {
                    _port = port;
                }
        
                public void Start()
                {
                    Console.WriteLine("wait for messages");
                    var thread = new Thread(ThreadStart);
                    thread.Start();
                }
                private void ThreadStart()
                {
                    var listener = new TcpListener(IPAddress.Any, _port);
                    listener.Start();
                    while (true)
                    {
                        var client = listener.AcceptTcpClient();
                        var clientThread = new Thread(ClientThreadStart);
                        clientThread.Start(client);
                    }
                }
                private void ClientThreadStart(object obj)
                {
                    var client = obj as TcpClient;
                    if (client == null) return;
                    using (var stream = client.GetStream())
                    {
                        const int lengthLength = sizeof(int) / sizeof(byte);
                        // Read the message length.
                        var lengthBuffer = new byte[lengthLength];
                        stream.ReadAsync(lengthBuffer, 0, lengthLength).Wait();
                        var messageLength = BitConverter.ToInt32(lengthBuffer, 0);
                        // Read the message.
                        var messageBuffer = new byte[messageLength];
                        stream.ReadAsync(messageBuffer, 0, messageLength).Wait();
                        var message = Encoding.Unicode.GetString(messageBuffer);
                        Console.WriteLine("Client says: " + message);
                    }
                    client.Close();
                }
            }
        }
