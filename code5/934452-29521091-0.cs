    String retVal = "";
    try
    {
         string url = "https://YourSite.com/";
         HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
          client.BaseAddress = new System.Uri(url);
          string cmd = "_api/contextinfo";
          client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
          client.DefaultRequestHeaders.Add("ContentType", "application/json");
          client.DefaultRequestHeaders.Add("ContentLength", "0");
          StringContent httpContent = new StringContent("");
          var response = client.PostAsync(cmd, httpContent).Result;
          if (response.IsSuccessStatusCode)
          {
              string content = response.Content.ReadAsStringAsync().Result;
               JsonObject val = JsonValue.Parse(content).GetObject();
               JsonObject d = val.GetNamedObject("d");
               JsonObject wi = d.GetNamedObject("GetContextWebInformation");
               retVal = wi.GetNamedString("FormDigestValue");
           }
     }
     catch
     { }
     return retVal;
