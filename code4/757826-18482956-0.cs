    // from model binder
    Request.Content.LoadIntoBufferAsync().Wait();
    var formData = Request.Content.ReadAsFormDataAsync().Result;
    
    // from filter
    Request.Content.LoadIntoBufferAsync().Wait();
    var formData = Request.Content.ReadAsFormDataAsync().Result;
