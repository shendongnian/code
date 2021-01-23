                var url = "YOUR_URL";
                var client = new HttpClient();
    
                var task = client.GetAsync(url);
                return task.Result.Content.ReadAsStringAsync().Result;
