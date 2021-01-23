    public HttpResponseMessage GetTravelers(string authkey)
    {
    var json = JsonConvert.SerializeObject(travelList, Global.JsonSettings);
     return new HttpResponseMessage()
     {
       Content = new StringContent(json, System.Text.Encoding.UTF8, 
    "text/html")
           };
