       using System;
       using System.Net;
       using System.Web;
       using System.Text;
        
        
        namespace com.tortoise.Controllers
        {
            public class VebraController
            {
                private string username = "foo";
                private string password = "foo";
        
                static string url = "www.test.com";
        
                public VebraController() {
        
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        
                NetworkCredential myCredentials = new System.Net.NetworkCredential(username,password);
                string usernamePassword = (username + password);
        
                CredentialCache cache = new CredentialCache(); 
        
                cache.Add(new Uri(url), "Basic", myCredentials); 
        
                request.Credentials = cache; 
        
                request.Headers.Add("Authorization", "Basic " + 
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(usernamePassword)); 
        
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Get the token from the response: 
                string token = response.GetResponseHeader("Token"); 
        
                response.Write(response.StatusCode); //you need to fix this
            }
            }
        }
