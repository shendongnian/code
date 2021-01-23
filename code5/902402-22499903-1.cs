    public static async Task<string> sendData()
    {
        TaskCompletionSource<string> complete = new TaskCompletionSource<string>();
        try
        {
            WebClient wc = new WebClient();
            var URI = new Uri("abc.com");
            string str = "data=1234";
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wc.UploadStringCompleted += (s, e) =>
            {
	            try
                {
                    string tt = e.Result;
                    complete.SetResult(tttt);
                }
                catch (Exception exc)
                {
                    complete.SetException(exc);
                }
            }
            wc.UploadStringAsync(URI, "POST", str);
        }
        catch (Exception ex)
        {
            string temp = ex.Message;
            complete.SetException(ex);
        }
        return await complete.Task;
    }
