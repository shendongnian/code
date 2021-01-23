    class Program
        {
            static void Main(string[] args)
            {
                var url = "http://localhost:8080";
                WebApp.Start(url, builder => builder.UseFileServer(enableDirectoryBrowsing:true));            
                Console.WriteLine("Listening at " + url);
                Console.ReadLine();
            }
        }
