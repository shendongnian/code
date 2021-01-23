    var responseTask = await client.SendAsync(request);
    var result = responseTask.ContinueWith(async r =>
                   {
                       var response = r.Result;
                       var value = await response.Content.ReadAsStringAsync();
                       if (!response.IsSuccessStatusCode)
                       {
                           var obj = new { message = "", ModelState = new Dictionary<string,string[]>() };
                           var x = JsonConvert.DeserializeAnonymousType(value, obj);
                           throw new AggregateException(x.ModelState.Select(kvp => new Exception(string.Format("{0}: {1}", kvp.Key, string.Join(". ", kvp.Value)))));
                       }
                   }).Result;
