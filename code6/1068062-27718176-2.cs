    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Replace with your code to fetch tweets here
            TweetsListBox.DataSource = FetchSomeTweets();
            // We've alread set the names of the properties to use `Id` and `Text` in the aspx
            TweetsListBox.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        long tweetIdToRetweet;
        if (long.TryParse(TweetsListBox.SelectedValue, out tweetIdToRetweet))
        {
            servis.Retweet(new RetweetOptions() { Id = tweetIdToRetweet });
        }
        else
        {
            // Display Error that user must select a tweet
        }
    }
