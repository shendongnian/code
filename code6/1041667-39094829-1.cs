    static void Main(string[] args)
            {
                var wssv = new WebSocketSharp.Server.WebSocketServer(System.Net.IPAddress.Any, 8080);
    
                wssv.KeepClean = true;
                
                wssv.AddWebSocketService<Service>("/service");
                
                wssv.Start();
                if (wssv.IsListening)
                {
                    Console.WriteLine("Listening on port {0}, and providing WebSocket services:", wssv.Port);
                    foreach (var path in wssv.WebSocketServices.Paths)
                        Console.WriteLine("- {0}", path);
                }
                Console.WriteLine("\nPress Enter key to stop the server...");
                Console.ReadLine();
    
                wssv.Stop();
            }
