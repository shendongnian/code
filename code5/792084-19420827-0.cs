    class Program
    {
        static void Main(string[] args)
        {
            Task task = TestAsync();
    
            Console.Write("Press any key...");
            task.wait();
            //Console.ReadKey();
            Console.WriteLine();
        }
    
    
        static async Task<string> TestAsync()
        {
            var c = new MyClient();
    
            try
            {
                var uri = new Uri("http://www.google.com/"); //valid address
                var s = await c.GetStringAsync(uri);
                Console.WriteLine(s.Length);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
    
            try
            {
                var uri = new Uri("http://www.foo.bah/"); //non-existent address
                var s = await c.GetStringAsync(uri);
                Console.WriteLine(s.Length);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
             //to avoid compiler error
             return null;
        }
    }
    
    
    class MyClient
    {
        public async Task<string> GetStringAsync(Uri uri)
        {
            var client = new HttpClient();
            return await client.GetStringAsync(uri);
        }
    }
