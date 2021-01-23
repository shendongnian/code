    private string GetLikes(string id)
    {
        FacebookClient fb = new FacebookClient(App.AccessToken);
        fb.GetCompleted += (o, e) =>
        {
            if (e.Error != null)
            {
                Dispatcher.BeginInvoke(()
                    =>
                    MessageBox.Show(e.Error.Message)
                    );
                return;
            }
            var result = (IDictionary<string, object>)e.GetResultData();
            var like_info = (JsonObject)result["summary"];
            Dispatcher.BeginInvoke(()
                =>
                {
                    return like_info["total_count"].ToString();
                }
                );
        };
        fb.GetTaskAsync("/"+id+"/likes?summary=1");
    }
