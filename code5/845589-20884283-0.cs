    var httpClient = new WebHCatHttpClient(new Uri("http://localhost:50111/"), "username", "password");
    string outputDir = "basichivejob";
    var task = httpClient.CreateHiveJob(@"select * from iris;", null, null, outputDir, null);
    task.Wait();
    var response = task.Result;
    var output = response.Content.ReadAsAsync<JObject>();
    output.Wait();
    response.EnsureSuccessStatusCode();
            
    string id = output.Result.GetValue("id").ToString();
    httpClient.WaitForJobToCompleteAsync(id).Wait();
