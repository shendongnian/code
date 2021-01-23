    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using RestSharp;
    using Plivo.API;
    
    namespace Plivo2
    {
        class Program
        {
            static void Main(string[] args)
            {
                            
                string auth_id = "MyAuthID";  // obtained from Plivo account dashboard
                string auth_token = "MyAuthTokey";  // obtained from Plivo account dashboard
                
                // Making a Call
                string from_number = "MyPliveNumber";
                string to_number = "TheNumberYouWantToContact";
    
                SendMessage(auth_id, auth_token,  from_number,  to_number,"Hello World!");
    
            }
    
            private static void CallPhone(string auth_id,string auth_token, string fromNumber, string toNumber){
    
                // Creating the Plivo Client
                RestAPI plivo = new RestAPI(auth_id, auth_token);
    
                IRestResponse<Call> response = plivo.make_call(new Dictionary<string, string>() {
                    { "from", fromNumber },
                    { "to", toNumber }, 
                    { "answer_url", "http://some.domain.com/answer/" }, 
                    { "answer_method", "GET" }
                });
    
                // The "Outbound call" API response has four properties -
                // message, request_uuid, error, and api_id.
                // error - contains the error response sent back from the server.
                if (response.Data != null)
                {
                    PropertyInfo[] proplist = response.Data.GetType().GetProperties();
                    foreach (PropertyInfo property in proplist)
                        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(response.Data, null));
                }
                else
                    Console.WriteLine(response.ErrorMessage);
            
            }
    
            private static void SendMessage(string auth_id,string auth_token, string fromNumber, string toNumber, string message) { 
                
                RestAPI plivo = new RestAPI(auth_id, auth_token);
    
                IRestResponse<MessageResponse> resp = plivo.send_message(new Dictionary<string, string>() 
                {
                    { "src", fromNumber },
                    { "dst", toNumber },
                    { "text", message },
                    { "url", "http://some.domain/receivestatus/" },
                    { "method", "GET" }
                });
                if (resp.Data != null)
                {
                    PropertyInfo[] proplist = resp.Data.GetType().GetProperties();
                    foreach (PropertyInfo property in proplist)
                        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(resp.Data, null));
                }
                else
                    Console.WriteLine(resp.ErrorMessage);
    		}
            
            
        }
    }
