            [Route("IPN")]
            [HttpPost]
            public IHttpActionResult IPN()
            {
                // if you want to use the PayPal sandbox change this from false to true
                string response = GetPayPalResponse(true);
    
                if (response == "VERIFIED")
                {
                    //Database stuff
                }
                else
                {
                    return BadRequest();
                }
    
                return Ok();
            }
    
            string GetPayPalResponse(bool useSandbox)
            {
                string responseState = "INVALID";
                // Parse the variables
                // Choose whether to use sandbox or live environment
                string paypalUrl = useSandbox ? "https://www.sandbox.paypal.com/"
                : "https://www.paypal.com/";
    
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(paypalUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
    
                    //STEP 2 in the paypal protocol
                    //Send HTTP CODE 200
                    HttpResponseMessage response = client.PostAsJsonAsync("cgi-bin/webscr", "").Result;
    
                    if (response.IsSuccessStatusCode)
                    {
                        //STEP 3
                        //Send the paypal request back with _notify-validate
                        string rawRequest = response.Content.ReadAsStringAsync().Result;
                        rawRequest += "&cmd=_notify-validate";
    
                        HttpContent content = new StringContent(rawRequest);
    
                        response = client.PostAsync("cgi-bin/webscr", content).Result;
    
                        if(response.IsSuccessStatusCode)
                        {
                            responseState = response.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
                
                return responseState;
            }
