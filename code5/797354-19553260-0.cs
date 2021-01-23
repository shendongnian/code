    ............
    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Forbidden);
    
    var json = JsonConvert.SerializeObject(
                        new ErrorModel
                        {
                            Description = "error stuff",
                            Status = "Ooops"
                        });
    response.Content = new StringContent(json);
    var tcs = new TaskCompletionSource<HttpResponseMessage>();
    tcs.SetResult(response);
    return tcs.Task;
