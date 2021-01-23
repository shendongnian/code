    static class Worker
    {
        public static Task<string> DoWork(string param)
        {
            var tcs = new TaskCompletionSource<string>();
            var request = (HttpWebRequest)WebRequest.Create("http://microsoft.com");
            try
            {
                request.BeginGetResponse(iar =>
                {
                    HttpWebResponse response = null;
                    try
                    {
                        response = (HttpWebResponse)request.EndGetResponse(iar);
                        tcs.SetResult(StringAnalyzer.AnalyzeProcessedString(response.ContentType));
                    }
                    catch (Exception exc)
                    {
                        tcs.SetException(exc);
                    }
                    finally
                    {
                        if (response != null)
                            response.Close();
                    }
                }, null);
            }
            catch (Exception exc)
            {
                tcs.SetException(exc);
            }
            return tcs.Task;
        }
    }
    class Program
    {
        private static List<string> _list = new List<string>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; ++i)
            {
                _list.Add("parameter" + i);
            }
            var tasks = (from param in _list select Worker.DoWork(param)).ToArray();
            Task.WaitAll(tasks);
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }
            Console.ReadLine();
        }
    }
    static class StringAnalyzer
    {
        public static string AnalyzeProcessedString(string data)
        {
            // Rather short, not CPU heavy
            System.Threading.Thread.Sleep(500);
            return ("Analyzed");
        }
    }
