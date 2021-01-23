    var httpClient = new HttpClient {
        Timeout = TimeSpan.FromMilliseconds(5)
    };
    var taskList = new List<Task<JObject>>();
    foreach (var myRequest in RequestsBatch)
    {
        // by virtue of not awaiting each call, you've already acheived parallelism
        taskList.Add(GetResponseAsync(endPoint, myRequest));
    }
        
    try
    {
        // asynchronously wait until all tasks are complete
        await Task.WhenAll(taskList.ToArray());
    }
    catch (Exception ex)
    {
    }
    async Task<JObject> GetResponseAsync(string endPoint, string myRequest)
    {
        // no Task.Run here!
        var response = await httpClient.PostAsJsonAsync<string>(
            string.Format("{0}api/GetResponse", endpoint), 
            myRequest);
        return await response.Content.ReadAsAsync<JObject>();
    }
