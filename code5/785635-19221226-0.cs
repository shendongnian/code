    byte[] imageData = ...
    var requestContent = new MultipartFormDataContent();
    var imageContent = new ByteArrayContent(imageData);
    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
    // Add the image
    requestContent.Add(imageContent, "image", "image.jpg");
    
    // Now add some additional parameters that will be bound to the UserReg object
    requestContent.Add(new StringContent(HttpUtility.UrlEncode("value1")), "param1");
    requestContent.Add(new StringContent(HttpUtility.UrlEncode("value2")), "param2");
    requestContent.Add(new StringContent(HttpUtility.UrlEncode("value3")), "param2.subparam1");
    var client = new HttpClient();
    var res = client.PostAsync("http://your_web_service_endpoint", requestContent).Result;
