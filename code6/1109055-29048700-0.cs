    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    
    public class Program
    {
        public void Main(string[] args)
        {
        }
    		
        internal class ServiceProxy
        {
            internal string Get(string predicate)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8001/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    HttpResponseMessage response = client.GetAsync(string.Format("TestService/LookupService" +
                                                                             "/GetCountries?term={0}", predicate)).Result;
    
                    if (response.IsSuccessStatusCode)
                    {
                         var answer = response.Content.ReadAsStringAsync().Result;
                         return answer;
                    }
    
                    return string.Empty;
                }
            }
        }
    }
