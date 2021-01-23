    public Task<IList<MenuItem>> ListMenus()
    {
        var completion = new TaskCompletionSource<IList<MenuItem>>();
        System.Uri targetUri = new System.Uri("http://xxxxxxxxxx.testshell.net/api/restaurant/menuitems/1");
        System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(targetUri);
        httpWebRequest.Method = "GET";
        httpWebRequest.Accept = "application/json";
        httpWebRequest.Headers["username"] = "info@xxxxxxxxxx.com";
        httpWebRequest.Headers["password"] = "xxxxxxxxxxxxxxxxxxxxxxxx";
        httpWebRequest.BeginGetResponse(ar =>
            {
                try
                {
                    using (var response = httpWebRequest.EndGetResponse(ar))
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            var responseObject =
                                Newtonsoft.Json.JsonConvert.DeserializeObject<MenuItemObject>(reader.ReadToEnd());
                            foreach (MenuItem loc in responseObject.data)
                            {
                                listitems.Add(loc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                completion.SetResult(listitems);
            }, null);
        return completion.Task;
    }
