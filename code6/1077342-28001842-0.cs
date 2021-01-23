    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.IO;
    namespace CSharpQuestions
    {
        class Program
        {
            static Stream GenerateStreamFromString(string s)
            {
                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(s);
                writer.Flush();
                stream.Position = 0;
                return stream;
            }
            static void Main(string[] args)
            {
                HttpClient h = new HttpClient();
                h.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                h.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0");
                h.DefaultRequestHeaders.Add("Referer", "http://urmia.divar.ir/browse/");
                h.DefaultRequestHeaders.Add("Pragma", "no-cache");
                h.DefaultRequestHeaders.Add("Host", "urmia.divar.ir");
                // h.DefaultRequestHeaders.Add("Content-Type","application/json; charset=UTF-8");
                h.DefaultRequestHeaders.Add("Connection", "keep-alive");
                h.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                h.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                h.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
                string myJSONRequest = "{\"jsonrpc\":\"2.0\",\"method\":\"getPostList\",\"id\":1,\"params\":[[[\"place2\",0,[\"10\"]]],0]}";
                HttpContent requestContent = new StreamContent(GenerateStreamFromString(myJSONRequest));
                Task<HttpResponseMessage> response = h.PostAsync("http://urmia.divar.ir/json/", requestContent);
                response.Wait(3000);
                byte[] responseText = response.Result.Content.ReadAsByteArrayAsync().Result;
                System.Console.WriteLine(responseText); // you would know what to do with the data ;)
            }
        
        }
    }
