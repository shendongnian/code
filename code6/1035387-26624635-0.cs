    using System.Net.Http;
    using System.Net.Http.Headers;
    using GoSaba.Models.Saba;
    
    namespace GoSaba.Controllers.Saba
    {
        class LoginController
        {
            //HTTP GET: Saba/api/login
            public async Task<string> GetCertificate(string host, string user, string password, string site)
            {
                StringBuilder getCertificate = new StringBuilder();
                
                if(!string.IsNullOrEmpty(host))
                {
                    using(var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(string.Format("http://{0}/", host));
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        httpClient.DefaultRequestHeaders.Add("user", user);
                        httpClient.DefaultRequestHeaders.Add("password", password);
                        httpClient.DefaultRequestHeaders.Add("site", site);
    
                        HttpResponseMessage httpResponse = await httpClient.GetAsync("Saba/api/login");
    
                        if(httpResponse.IsSuccessStatusCode)
                        {
                            LoginModel.GetCertificate saba = await httpResponse.Content.ReadAsAsync<LoginModel.GetCertificate>();//LoginModel.GetCertificate is model.
                            getCertificate.Append(saba.certificate);
                        }
                    }
                }
    
                return getCertificate.ToString();
            }
        }
    }
