    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Web;
    
    namespace GetAccessTokenSample
    {
      class Program
      {
        private static string baseUrl = "https://localhost:44305";
    
        static void Main(string[] args)
        {
    
          Console.WriteLine("Enter Username: ");
          string username= Console.ReadLine();
          Console.WriteLine("Enter Password: ");
          string password = Console.ReadLine();
    
          LoginTokenResult accessToken = GetLoginToken(username,password);
          if (accessToken.AccessToken != null)
          {
            Console.WriteLine(accessToken);
          }
          else
          {
            Console.WriteLine("Error Occurred:{0}, {1}", accessToken.Error, accessToken.ErrorDescription);
          }
    
        }
    
    
        private static LoginTokenResult GetLoginToken(string username, string password)
        {
    
          HttpClient client = new HttpClient();
          client.BaseAddress = new Uri(baseUrl);
          //TokenRequestViewModel tokenRequest = new TokenRequestViewModel() { 
          //password=userInfo.Password, username=userInfo.UserName};
          HttpResponseMessage response =
            client.PostAsync("Token",
              new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                HttpUtility.UrlEncode(username),
                HttpUtility.UrlEncode(password)), Encoding.UTF8,
                "application/x-www-form-urlencoded")).Result;
    
          string resultJSON = response.Content.ReadAsStringAsync().Result;
          LoginTokenResult result = JsonConvert.DeserializeObject<LoginTokenResult>(resultJSON);
    
          return result;
        }
    
        public class LoginTokenResult
        {
          public override string ToString()
          {
            return AccessToken;
          }
    
          [JsonProperty(PropertyName = "access_token")]
          public string AccessToken { get; set; }
    
          [JsonProperty(PropertyName = "error")]
          public string Error { get; set; }
    
          [JsonProperty(PropertyName = "error_description")]
          public string ErrorDescription { get; set; }
          
        }
    
      }
    }
