    namespace ConsoleApplication1
    {
        using System;
        using System.IO;
        using System.Net;
        using Newtonsoft.Json;
    
        class Program
        {
            static void Main()
            {
                Console.WriteLine(GetRestData(@"http://localhost:52833//api/Departments/PostDepartment/42/76TrombonesLedTheZeppelin"));
                Console.ReadLine();
            }
    
            private static dynamic GetRestData(string uri)
            {
    
                var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                webRequest.Method = "POST";
                webRequest.ContentLength = 0;
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var reader = new StreamReader(webResponse.GetResponseStream());
                string s = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(s);
    
            }
        }
    }
