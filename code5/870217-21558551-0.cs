    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dir = new DirectoryInfo(@"C:\Windows");
    
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine("Name: " + file.Name + "\r\nSize: " + file.Length + "\r\nType: " + file.GetType());
                }
                Console.ReadKey();
    
            }
        }
    }
