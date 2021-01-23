    public TwitterStatus searchTweets(string targetName, string keyword,DateTime start, DateTime end)
        {
            IEnumerable<TwitterStatus> list = twitter.ListTweetsOnUserTimeline(new ListTweetsOnUserTimelineOptions() { ScreenName = targetName }); 
            foreach (TwitterStatus item in list)
            {
                if (item.Text.Contains(keyword) && item.CreatedDate>start&&item.CreatedDate<end)
                {
                    return item;
                }
            }
            return null;
        }
