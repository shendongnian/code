      class Program
      {
        public static List<StackRoot> AllQuestionRoot = new List<StackRoot>();
        public static object criticalSection = new object();
        public static CountdownEvent countdown = new CountdownEvent(10);
        static void Main(string[] args)
        {
            MyWebClient client = new MyWebClient();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(HandleQuestionDownloadCompleted);
                    client.DownloadStringAsync(new Uri("http://api.stackexchange.com/2.2/questions?page=1&pagesize=20&order=desc&sort=creation&tagged=reporting-services&site=stackoverflow"), waiter);
                }
            }
            catch (WebException exception)
            {
                string responseText;
                using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            //Do some other stuff
            //calculate values 
            //How to make sure all my asynch DownloadStringCompleted calls are completed ?
            //process AllQuestionRoot data  depending on some values calculated above
            //save the AllQuestionRoot to database and directory
            // Wait until all have been completed.
            countdown.Wait();
            Console.ReadKey();
        }
        private static void HandleQuestionDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null || !e.Cancelled)
            {
                StackRoot responseRoot = JsonConvert.DeserializeObject<StackRoot>(e.Result);
                
                // Adding to List<T> is not thread safe.
                lock (criticalSection)
                {
                    AllQuestionRoot.Add(responseRoot);
                }
                // Signal completed. 
                countdown.Signal();
            }
        }
    }
