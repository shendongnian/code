    var content = "this is some content";
    var response = new HttpResponseMessage
    {
    	Content = new StringContent(content)
    };
    response.Content.Headers.Add(@"Content-Length", content.Length.ToString());
