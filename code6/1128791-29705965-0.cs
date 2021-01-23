        static void Main(string[] args)
        {
            GetAPI().Wait();
            Console.WriteLine("Hello");
            Console.ReadLine();
        }
    
        public static async Task GetAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Get", "application/json");
                var response = await client.GetAsync("http://google.com/");
    
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                Console.ReadLine();
            }
        }
