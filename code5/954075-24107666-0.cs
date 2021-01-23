    using System;
    using System.Net;
    using System.IO;
    using System.Web.Script.Serialization; // Require adding System.Web.Extentions.dll
    class SolrHeloWorld // C#
    {
        static void Main()
        {
            Uri uri = new Uri("http://192.168.1.211:8983/solr/collection1/select?q=banana&start=0&rows=50&wt=json&indent=true&defType=edismax");
            WebRequest request = HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            response.Close();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic jsonObject = serializer.Deserialize<dynamic>(jsonResponse);
            dynamic dd = jsonObject["response"]["docs"]; 
            Object[] results = (Object[])dd;
            foreach (Object res in results)
            {
                Console.WriteLine(serializer.Serialize(res));
            }
        }
    } 
