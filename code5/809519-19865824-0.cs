    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    namespace AsyncTestCase.Driver
    {
        public class AsyncTestCase
        {
            public AsyncTestCase()
            { }
            public string GetContent(string url)
            {
                Task<string> task = this.GetContentAsync(url);
                return task.Result;
            }
            public async Task<string> GetContentAsync(string url)
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp(url);
                HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
                using (Stream stream = response.GetResponseStream())
                {
                    using (TextReader reader = new StreamReader(stream))
                    {
                        string content = await reader.ReadToEndAsync();
                        return content;
                    }
                }
            }
        }
    }
