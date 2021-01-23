        public class PayPalValidator
        {
            public bool ValidateIPN(string body)
            {
                var paypalResponse = GetPayPalResponse(true, body);
                return paypalResponse.Equals("VERIFIED");
            }
    
            private string GetPayPalResponse(bool useSandbox, string rawRequest)
            {
                string responseState = "INVALID";
                string paypalUrl = useSandbox ? "https://www.sandbox.paypal.com/"
                : "https://www.paypal.com/";
    
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(paypalUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                    HttpResponseMessage response = client.PostAsJsonAsync("cgi-bin/webscr", "").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        rawRequest += "&cmd=_notify-validate";
                        HttpContent content = new StringContent(rawRequest);
                        response = client.PostAsync("cgi-bin/webscr", content).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            responseState = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
                return responseState;
            }
        }
