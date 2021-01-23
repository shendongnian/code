     if (!response.IsSuccessStatusCode)
     {                                
        dynamic responseForInvalidStatusCode = response.Content.ReadAsAsync<dynamic>();
        Newtonsoft.Json.Linq.JContainer msg = responseForInvalidStatusCode.Result;
        result = msg.ToString();
     }
