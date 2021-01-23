    var client = new RestClient("http://myurl.com/api/");
    
    var request = new RestRequest("getCatalog?token={token}", Method.GET); 
    request.AddParameter("token", "saga001", ParameterType.UrlSegment);   
    // request.AddUrlSegment("token", "saga001"); 
    
    request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
    
    var queryResult = client.Execute(request);
    
    Console.WriteLine(queryResult.Data);
    // Console.WriteLine(queryResult.Content);
