    static void Main(string[] args)
        {
            using (var client = new SshClient("host", "name", "pwd"))
            {
                client.Connect();
                var port = new ForwardedPortDynamic(7575);
                client.AddForwardedPort(port);
                port.Exception += delegate (object sender, ExceptionEventArgs e)
                {
                    Console.WriteLine(e.Exception.ToString());
                };
                port.Start();
                Console.ReadKey();
            }
        }
