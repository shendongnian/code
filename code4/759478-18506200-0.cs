    if (response.StatusCode != HttpStatusCode.OK && response.StatusCode !=   HttpStatusCode.Created)
    {
         throw new Exception(response.Content);
    }
    RestResponseCookie cookie = response.Cookies[0];
    var anotherRequest = new RestRequest();
    anotherRequest.AddCookie(cookie.Name, cookie.Value);
    anotherRequest.AddHeader("content-type", "application/xml");
    ...
    IRestResponse anotherResponse = client.Execute(anotherRequest);
