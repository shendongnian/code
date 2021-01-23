    using Newtonsoft.Json; //see http://www.newtonsoft.com/json
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DoceboClient
    {
        class CallDoceboAPI
        {
            static void Main(string[] args)
            {
                string url = "https://YOUR_DOCEBO_PORTAL_URL"; //https is mandatory!
                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
    
                //Obtain token
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/oauth2/token");
                string postParametersForToken = "client_id=YOUR_DOCEBO_CLIENT_ID&client_secret=YOUR_DOCEBO_CLIENT_SECRET&grant_type=password&username=YOUR_DOCEBO_USERNAME&password=YOUR_DOCEBO_PASSWORD&scope=api";
                request.ContentType = @"application/x-www-form-urlencoded";
                Byte[] byteArray = encoding.GetBytes(postParametersForToken);
                request.ContentLength = byteArray.Length;
                request.Method = "POST";
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                string token = "";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string result = reader.ReadToEnd();
                        DoceboToken dt = JsonConvert.DeserializeObject<DoceboToken>(result);
                        token = dt.access_token;
                    }
                }
    
                //invoke API, e.g. "/user/count" 
                string api = "/api/user/count";
                string postParametersForAPI = "status=all"; //if more than 1 parameter, concat them as &parmName=parmValue
                request = (HttpWebRequest)WebRequest.Create(url + api);
                byteArray = encoding.GetBytes(postParametersForAPI + "&access_token=" + token);
                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/x-www-form-urlencoded";
                request.Method = "POST";
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        string result = reader.ReadToEnd();
                        UserCountResponse ucr = JsonConvert.DeserializeObject<UserCountResponse>(result);
                        //get the result
                        int count = ucr.count;
                    }
                }
            }
        }
    
        class UserCountResponse
        {
            public bool success;
            public int count;
        }
    
        class DoceboToken
        {
            public string access_token;
        }
    
    }
