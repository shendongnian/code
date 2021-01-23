    HttpResponseMessage response = client.PostAsJsonAsync(ConfigurationManager.AppSettings[Constants.BidApiBaseURL], objClientBidRequest).Result;
        if (response.StatusCode.ToString() == "OK")
        {
            // Send request after 2 second for bid result
            Thread.Sleep(2000);
            string bidContent = "<iframe src=maps.google.com?gps=....></iframe>";
            for (int i = 1; i <= 4; i++)
            {
                lstExpertBidResponse.Add(
                    new BidResponse(
                        objClientBidRequest.RequestId.ToString(),
                        bidContent,
                        i.ToString(),
                        "W" + i.ToString(),
                        GetFeedBackScore("W" + i.ToString()),
                        GetExpertID("W" + i.ToString())
                        ));
            }
        }
      
