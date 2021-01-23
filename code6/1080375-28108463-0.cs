    var request = System.Net.Http.HttpRequestMessage>();
    request.RequestUri = new Uri("http://localhost/");
    // act
    var controller = new ContentController(mockService.Object);
    var actionResult = controller.PostAsync(new ContentModel {
        Heading = "New Heading"
    }, request).Result;
