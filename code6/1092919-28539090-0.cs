        static bool CheckForInternetConnection(int timeOut = 3000)
        {
            var task = CheckForInternetConnectionTask(timeOut);
            return task.Wait(timeOut) && task.Result;
        }
        static Task<bool> CheckForInternetConnectionTask(int timeOut = 3000)
        {
            return Task.Factory.StartNew
                (() =>
                {
                    try
                    {
                        var client = (HttpWebRequest) WebRequest.Create("http://google.com/");
                        client.Method = "HEAD";
                        client.Timeout = timeOut;
                        using (var response = client.GetResponse())
                        using (response.GetResponseStream())
                        {
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                });
        }
