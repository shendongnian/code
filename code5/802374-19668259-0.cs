    public class SeperateClass
    {
        static int numberOfRequest = 500;
        public async static void LoadUrlsAsync()
        {
            var startTime = DateTime.Now;
            Console.WriteLine("LoadUrlsAsync Start - {0}", startTime);
            
            var tasks = new List<Task<string>>();
    
            for (int i = 0; i < numberOfRequest; i++)
            {
                var request = WebRequest.Create(@"http://www.google.com/images/srpr/logo11w.png") as HttpWebRequest;
                request.Method = "GET";
    
                var task = LoadUrlAsync(request);
                tasks.Add(task);
            }
    
            var results = await Task.WhenAll(tasks);
    
            var stopTime = DateTime.Now;
            var duration = (stopTime - startTime);
            Console.WriteLine("LoadUrlsAsync Complete - {0}", stopTime);
            Console.WriteLine("LoadUrlsAsync Duration - {0}ms", duration);
        }
    
        async static Task<string> LoadUrlAsync(WebRequest request)
        {
            string value = string.Empty;
            using (var response = await request.GetResponseAsync())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                value = reader.ReadToEnd();
                Console.WriteLine("{0} - Bytes: {1}", request.RequestUri, value.Length);
            }
    
            return value;
        }
    }
    
    public class SeperateClassSync
    {
        static int numberOfRequest = 500;
        public async static void LoadUrlsSync()
        {
            var startTime = DateTime.Now;
            Console.WriteLine("LoadUrlsSync Start - {0}", startTime);
            
            var tasks = new List<Task<string>>();
    
            for (int i = 0; i < numberOfRequest; i++)
            {
                var request = WebRequest.Create(@"http://www.google.com/images/srpr/logo11w.png") as HttpWebRequest;
                request.Method = "GET";
    
                var task = LoadUrlSync(request);
                tasks.Add(task);
            }
    
            var results = await Task.WhenAll(tasks);
    
            var stopTime = DateTime.Now;
            var duration = (stopTime - startTime);
            Console.WriteLine("LoadUrlsSync Complete - {0}", stopTime);
            Console.WriteLine("LoadUrlsSync Duration - {0}ms", duration);
        }
    
        async static Task<string> LoadUrlSync(WebRequest request)
        {
            string value = string.Empty;
            using (var response = request.GetResponse())//Still async FW, just changed to Sync call here
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                value = reader.ReadToEnd();
                Console.WriteLine("{0} - Bytes: {1}", request.RequestUri, value.Length);
            }
    
            return value;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            SeperateClass.LoadUrlsAsync();
            Console.ReadLine();//record result and run again
    
            SeperateClassSync.LoadUrlsSync();
            Console.ReadLine();
        }
    }
