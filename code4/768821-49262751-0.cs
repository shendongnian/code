    static void PostSync (string url, string parametersData)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded"; // or "application/json" or ...
            try
            {
                string htmlResult = wc.UploadString(url, parametersData);  // or UploadValues, UploadFile, ... 
                JObject jsonObject = null;
                try
                {
                    jsonObject = JObject.Parse(htmlResult);
                }
                catch (JsonException ex)
                {
                    onResult(StatusCode.JsonError);
                }
                onResult(StatusCode.Ok, jsonObject);
            }
            catch (System.Net.WebException ex)
            {
                onResult(StatusCode.NetworkError);
            }
        }
    }
    static void PostAsync(string url, string parametersData)
    {
        using (WebClient wc = new WebClient())
        {
            wc.UploadStringCompleted += (Object sender, UploadStringCompletedEventArgs e) =>
            {
                if (e.Error != null)
                    onResult(StatusCode.NetworkError);
                JObject jsonObject = null;
                try
                {
                    jsonObject = JObject.Parse(e.Result);
                }
                catch (JsonException ex)
                {
                    onResult(StatusCode.JsonError);
                }
                onResult(StatusCode.Ok, jsonObject);
            };
            try
            {
                wc.UploadStringAsync(new Uri(url, UriKind.Absolute), parametersData);
            }
            catch (System.Net.WebException ex)
            {
                onResult(StatusCode.NetworkError);
            }
        }
    }
    static async void PostTaskAsync(string url, string parametersData)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded"; // or "application/json" or ...
            try
            {
                string htmlResult = await wc.UploadStringTaskAsync(url, parametersData);  // or UploadValues, UploadFile, ... 
                JObject jsonObject = null;
                try
                {
                    jsonObject = JObject.Parse(htmlResult);
                }
                catch (JsonException ex)
                {
                    onResult(StatusCode.JsonError);
                }
                onResult(StatusCode.Ok, jsonObject);
            }
            catch (System.Net.WebException ex)
            {
                onResult(StatusCode.NetworkError);
            }
        }
    }
