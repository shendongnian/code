    var controller = new MyController();
    controller.Request = new HttpRequestMessage();
    controller.Configuration = new HttpConfiguration();
    controller.Request.Content = new StringContent("{ x: 21 }",
         Encoding.Unicode);
    controller.Request.Content.Headers.ContentType.MediaType =
         "application/json";
    
