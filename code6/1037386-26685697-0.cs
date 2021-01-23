    using(System.Net.Http.HttpClient client = new System.Net.Http.HttpClient()) {
        //Initialize a HttpClient
        client.BaseAddress = new Uri(strURL);
        client.Timeout = new TimeSpan(0, 0, 60);
        client.DefaultRequestHeaders.Accept.Clear();
        //I changed this line.
        System.Net.Http.HttpContent content = new System.Net.Http.FormUrlEncodedContent(convertNameValueCollectionToKeyValuePair(HttpUtility.ParseQueryString(objPostData.ToString()));
        using(System.Net.Http.HttpResponseMessage response = client.PostAsync(strAddr, content).Result) {}
    }
