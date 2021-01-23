        HttpClient client = new HttpClient();
        var nameValues = new Dictionary<string, string>();
        nameValues.Add("Name", "hi");
        var Name = new FormUrlEncodedContent(nameValues);
        client.PostAsync("http://localhost:23133/api/values", Name).ContinueWith(task =>
        {
            var responseNew = task.Result;
            Console.WriteLine(responseNew.Content.ReadAsStringAsync().Result);
        });
