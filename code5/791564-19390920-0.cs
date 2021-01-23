        static void Main(string[] args) {
            var server = new Task(Server);
            server.Start();
            System.Threading.Thread.Sleep(10); // give server thread a chance to setup
            try {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 1500);
                Console.WriteLine("Connected.");
                var data = new byte[100];
                var hello = ASCIIEncoding.ASCII.GetBytes("Hello");
                Console.WriteLine("Sending data.....");
                using (var stream = client.GetStream()) {
                    stream.Write(hello, 0, hello.Length);
                    stream.Flush();
                    Console.WriteLine("Data sent.");
                    // You could then read data from server here:
                    var returned = stream.Read(data, 0, data.Length);
                    var rec = new String(ASCIIEncoding.ASCII.GetChars(data, 0, data.Length));
                    rec = rec.TrimEnd('\0');
                    if (rec == "How are you?") {
                        var fine  = ASCIIEncoding.ASCII.GetBytes("fine and you?");
                        stream.Write(fine, 0, fine.Length);
                        }
                    }
                client.Close();
                Console.ReadLine();
                }
            catch (Exception e) {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.ReadLine();
                }
            }
        public static void Server() {
            try {
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                Console.WriteLine("*Starting TCP listener...");
                TcpListener listener = new TcpListener(ipAddress, 1500); // generally use ports > 1024
                listener.Start();
                Console.WriteLine("*Server is listening on " + listener.LocalEndpoint);
                Console.WriteLine("*Waiting for a connection...");
                while (true) {
                    Socket client = listener.AcceptSocket();
                    while (client.Connected) {
                        Console.WriteLine("*Connection accepted.");
                        Console.WriteLine("*Reading data...");
                        byte[] data = new byte[100];
                        int size = client.Receive(data);
                        Console.WriteLine("*Recieved data: ");
                        var rec = new String(ASCIIEncoding.ASCII.GetChars(data, 0, size));
                        rec = rec.TrimEnd('\0');
                        Console.WriteLine(rec);
                        if (client.Connected == false) {
                            client.Close();
                            break;
                            }
                        // you would write something back to the client here
                        if (rec == "Hello") {
                            client.Send(ASCIIEncoding.ASCII.GetBytes("How are you?"));
                            }
                        if (rec == "fine and you?") {
                            client.Disconnect(false);
                            }
                        }
                    }
                listener.Stop();
                }
            catch (Exception e) {
                Console.WriteLine("Error: " + e.StackTrace);
                Console.ReadLine();
                }
            }
        }
