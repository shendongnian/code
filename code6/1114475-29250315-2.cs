    public string PostToTwitter(string PostData, string SelectedMedia)
        {
            string tweetresp = "";
            DataSet ds = new DataSet();
            try
            {
                ds = Common.CheckTwitterAccessToken();
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    Influencer objinfluencer = new Influencer();
                    objinfluencer.TwitterConnect();
                }
                var oauth = new OAuthInfo
                {
                    AccessToken = Convert.ToString(Session["twitter_token"]),
                    AccessSecret = Convert.ToString(Session["twitter_token_secret"]),
                    ConsumerKey = Convert.ToString(ConfigurationSettings.AppSettings["TwitterConsumerKey"]) ,
                    ConsumerSecret =Convert.ToString(ConfigurationSettings.AppSettings["TwitterConsumerSecret"]) 
                };
                var twitter = new TinyTwitter(oauth);
                List<string> li = new List<string>();
                string[] files = SelectedMedia.Split(',');
                List<string> FileList = new List<string>();
                string media = "";
                
                if (!string.IsNullOrEmpty(SelectedMedia))
                {
                    foreach (string file in files)
                        FileList.Add(Server.MapPath(file));
                    foreach (string item in FileList)
                    {
                        li.Add(GetMediaId(twitter, item));
                    }
                    media = string.Join(",", li);
                }
                //li.Add(GetMediaId(twitter, file1));
                if (!string.IsNullOrEmpty(SelectedMedia))
                {
                     tweetresp = twitter.UpdateStatuswithmedia(PostData, media);
                }
                else
                tweetresp = twitter.UpdateStatus(PostData);
            }
            catch (Exception ex)
            {
            }
            return tweetresp;
        }
