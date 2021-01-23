    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            servis = new TwitterService(consumer key,secret,token,token); 
            tweetid.Items.Clear();
            ListBox2.Items.Clear();
            IEnumerable<TwitterStatus> anasayfa = servis.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { Count = 200 });
            var gelen = servis.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions { Count = 200, MaxId = anasayfa.Last().Id });
            foreach (var tweet in gelen)
            {
                    tweetid.Items.Add(tweet.Id.ToString());
                    ListBox2.Items.Add(tweet.Text);   
            }
        }
    }
