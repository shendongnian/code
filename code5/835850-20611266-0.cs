    if (NetworkInterface.GetIsNetworkAvailable())
    {
        //Obtain keys by registering your app on https://dev.twitter.com/apps
        var service = new TwitterService("abc", "abc");
        service.AuthenticateWith("abc", "abc");
    
        //ScreenName is the profile name of the twitter user.
        service.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = "the_appfactory" }, (ts, rep) =>
        {
            if (rep.StatusCode == HttpStatusCode.OK)
            {
                //bind
                this.Dispatcher.BeginInvoke(() => { tweetList.ItemsSource = ts; });
            }
        });
    }
    else
    {
    
        MessageBox.Show("Please check your internet connestion.");
    }
