    using System.Net.Http;
    ...
    var uri = new Uri("http://81.137.212.183:4483/Simple/index.htm");
    var task = new HttpClient().GetAsync(uri);
    if (task.Wait(TimeSpan.FromSeconds(1)) && task.Result.IsSuccessStatusCode)
    {
        // SUCCESS!
    }
    else
    {
        // FAILURE... try next camera
    }
