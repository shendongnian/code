    static void Main(string[] args)
        {
            Console.WriteLine("here");
            Task.Run(async () => 
            {
                await LoadData();
            }).Wait();
            Console.WriteLine("there");
        }
        static async private Task LoadData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("http://somelinks");
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                Console.ReadLine();
            }
        }
