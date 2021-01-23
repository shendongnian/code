    public static async Task<string> SendRequestPostResponse()
        {
            try
            {
                var postRequest = (HttpWebRequest)WebRequest.Create("your Url Here");
               
                postRequest.ContentType = "application/x-www-form-urlencoded"; // Whichever content type you want to POST
                postRequest.Method = "POST";
                using (var requestStream = await postRequest.GetRequestStreamAsync())
                {
                    byte[] postDataArray = Encoding.UTF8.GetBytes("your data here"); // Data for the POST request here
                    await requestStream.WriteAsync(postDataArray, 0, postDataArray.Length);
                }
                WebResponse postResponse = await postRequest.GetResponseAsync();
                if (postResponse != null)
                {
                    var postResponseStream = postResponse.GetResponseStream();
                    var postStreamReader = new StreamReader(postResponseStream);
                   
                    string response = await postStreamReader.ReadToEndAsync();
                   
                    return response;
                }
                return null;
            }
    }
