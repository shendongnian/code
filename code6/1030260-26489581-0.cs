    namespace OAuthTwitterWrapper
    {
    public class OAuthTwitterWrapper : IOAuthTwitterWrapper
    {
    public IAuthenticateSettings AuthenticateSettings { get; set; }
    public ITimeLineSettings TimeLineSettings { get; set; }
    public ISearchSettings SearchSettings { get; set; }
    [InjectConstructor]
    public OAuthTwitterWrapper()
    {
        string oAuthConsumerKey = ConfigurationManager.AppSettings["oAuthConsumerKey"];
        string oAuthConsumerSecret = ConfigurationManager.AppSettings["oAuthConsumerSecret"];
        string oAuthUrl = ConfigurationManager.AppSettings["oAuthUrl"];
        AuthenticateSettings = new AuthenticateSettings { OAuthConsumerKey = oAuthConsumerKey, OAuthConsumerSecret = oAuthConsumerSecret, OAuthUrl = oAuthUrl };
        string screenname = ConfigurationManager.AppSettings["screenname"];
        string include_rts = ConfigurationManager.AppSettings["include_rts"];
        string exclude_replies = ConfigurationManager.AppSettings["exclude_replies"];
        int count = Convert.ToInt16(ConfigurationManager.AppSettings["count"]);
        string timelineFormat = ConfigurationManager.AppSettings["timelineFormat"];         
        TimeLineSettings = new TimeLineSettings
        {
            ScreenName = screenname,
            IncludeRts = include_rts,
            ExcludeReplies = exclude_replies,
            Count = count,
            TimelineFormat = timelineFormat
        };
        string searchFormat = ConfigurationManager.AppSettings["searchFormat"];
        string searchQuery = ConfigurationManager.AppSettings["searchQuery"];
        SearchSettings = new SearchSettings
        {
            SearchFormat = searchFormat,
            SearchQuery = searchQuery
        };
