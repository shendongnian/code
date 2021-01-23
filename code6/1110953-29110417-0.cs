    var taskList = new List<Task<JObject>>();
    foreach (var myRequest in RequestsBatch)
    {
        taskList.Add(GetResponse(endPoint, myRequest));
    }
    Task.WaitAll(taskList.ToArray());
        
    public Task<JObject> GetResponse(string endPoint, string myRequest)
    {
        return Task.Run(() =>
            {
                HttpClient httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromMilliseconds(5);
                HttpResponseMessage response = httpClient.PostAsJsonAsync<string>(string.Format("{0}api/GetResponse", endpoint), myRequest);
                JObject resultResponse = response.Content.ReadAsAsync<JObject>();
            });
    }
