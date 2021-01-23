    public static async Task<string> CheckReceiptWithAppStore()
        {
            string responseStr = null;
            
            string uri = "https://sandbox.itunes.apple.com/verifyReceipt";
            string receiptData = // Get your receipt from wherever you store it
            var json = new JObject(new JProperty("receipt-data", receiptData), 
                new JProperty("password", "paste-your-shared-secret-here")).ToString();
            json = json.ToString();
        
            using (var httpClient = new HttpClient())
            {        
                if (receiptData != null)
                {
                    HttpContent content = new StringContent(json);
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.PostAsync(uri, content);
                        HttpResponseMessage response = await getResponse;
                        responseStr = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error verifying receipt: " + e.Message);
                    }
                }
            }
            return responseStr;
        }
