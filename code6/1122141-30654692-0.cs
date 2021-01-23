    using System.IO;
    using System;
    using System.Net;
    using System.Text;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    
    class Program
    {
        static void Main()
        {
    		sendRequest("https://api.imgur.com/oauth2/token");
        }
        
        private static void sendRequest(String url){
        
            using(WebClient client = new WebClient())
            {
                System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("client_id", "Your client_id");
                reqparm.Add("client_secret", "Your client_secret");
                reqparm.Add("grant_type", "authorization_code");
                reqparm.Add("code", "your returned code");
                
                ServicePointManager.ServerCertificateValidationCallback = 
                    delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                        { return true; };
                System.Net.ServicePointManager.Expect100Continue = false;
                byte[] responsebytes = client.UploadValues(url, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
                Console.WriteLine(responsebody);
            }
        }
     }
               
