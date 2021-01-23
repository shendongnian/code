    class Program
    {
        static void Main(string[] args)
        {
            var task = Worker.DoWorkAsync();
            task.Wait(); //stop and wait until our async method completed
            foreach (var item in task.Result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
    static class Worker
    {
        public async static Task<IEnumerable<string>> DoWorkAsync()
        {
            List<string> results = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                var request = (HttpWebRequest)WebRequest.Create("http://microsoft.com");
                using (var response = await request.GetResponseAsync())
                {
                    results.Add(response.ContentType);
                }
            }
            return results;
        }
    }
