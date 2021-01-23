        public ActionResult Index()
        {
            List<TwitterModel> tweets = GetTweets("#twitter");
            return View(tweets);
           // return View();
        }
        public List<TwitterModel> GetTweets(string twitterHashTag)
        {
            List<TwitterModel> lstTweets = new List<TwitterModel>();
            // New Code added for Twitter API 1.1
            if (!string.IsNullOrEmpty(twitterHashTag))
            {
                var twitter = new TwitterHelper(ConfigurationManager.AppSettings["OauthConsumerKey"],
                                                                ConfigurationManager.AppSettings["OauthConsumerKeySecret"],
                                                                ConfigurationManager.AppSettings["OauthAccessToken"],
                                                                ConfigurationManager.AppSettings["OauthAccessTokenSecret"]);
           
                var response = twitter.GetTweets(twitterHashTag, 100);
                dynamic timeline = System.Web.Helpers.Json.Decode(response);
                foreach (var tweet in timeline)
                {
                    System.Web.Helpers.DynamicJsonArray tweetJson = tweet.Value as System.Web.Helpers.DynamicJsonArray;
                    if (tweetJson != null && tweetJson.Count() > 0)
                        foreach (System.Dynamic.DynamicObject item in tweetJson)
                        {
                            TwitterModel tModel = new TwitterModel();
                            tModel.Id = ((dynamic)item).id.ToString();
                            tModel.AuthorName = ((dynamic)item).user.name;
                            tModel.AuthorUrl = ((dynamic)item).user.url;
                            tModel.Content = ((dynamic)item).Text;
                            string publishedDate = ((dynamic)item).created_at;
                            publishedDate = publishedDate.Substring(0, 19);
                            tModel.Published = DateTime.ParseExact(publishedDate, "ddd MMM dd HH:mm:ss", null);
                            tModel.ProfileImage = ((dynamic)item).user.profile_image_url;
                            lstTweets.Add(tModel);
                        }
                }
            }
            return lstTweets;
        }
