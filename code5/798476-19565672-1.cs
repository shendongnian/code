        static void Main(string[] args)
        {
            var content = GetUrlContents("http://www.google.com");
            if (content.Result.Contains("Google"))
                Console.WriteLine("Google found!");
            Console.Read();
        }
        static async Task<string> GetUrlContents(string url)
        {
            HttpClient client = new HttpClient();
            var content = await client.GetStringAsync(url);
            return content;
        }
