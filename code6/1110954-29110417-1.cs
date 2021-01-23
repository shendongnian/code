    var taskList = new List<Task<JObject>>();
    foreach (var myRequest in RequestsBatch)
    {
        taskList.Add(GetResponse(endPoint, myRequest));
    }
    
    try
    {
        Task.WaitAll(taskList.ToArray());
    }
    catch (Exception ex)
    {
    }
    public Task<JObject> GetResponse(string endPoint, string myRequest)
    {
        return Task.Run(() =>
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.PostAsJsonAsync<string>(
                     string.Format("{0}api/GetResponse", endpoint), 
                     myRequest, 
                     new CancellationTokenSource(TimeSpan.FromMilliseconds(5)).Token);
                JObject resultResponse = response.Content.ReadAsAsync<JObject>();
            });
    }
