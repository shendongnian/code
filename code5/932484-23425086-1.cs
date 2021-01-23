            OAuthTokens Token = new OAuthTokens();
            Token.ConsumerKey = twitterdata.AppId;
            Token.ConsumerSecret = twitterdata.AppSecret;
            Token.AccessToken = twitterdata.TokenId;
            Token.AccessTokenSecret = twitterdata.Tokensecret;
            string postedMsgID = TwitterPost(Token, PostMsg, ref strErrorMsg);
     private string TwitterPost(OAuthTokens Token, string PostMsg, ref StringBuilder strErrorMsg)
        {
            log.Info("Start Tweeting At==> " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            #region Called the Tweeting API for Tweet the News.
            string MsgID = "-1";
                try
                {
                    StatusUpdateOptions options = new StatusUpdateOptions();
                    options.UseSSL = true;
                    TwitterResponse<TwitterStatus> ts = TwitterStatus.Update(Token, PostMsg, options);
                    if (ts.ResponseObject != null)
                        MsgID = Convert.ToString(ts.ResponseObject.Id);
                    if (!string.IsNullOrEmpty(ts.Content.Trim()))
                    {
                        if (ts.Content.Trim().ToLower().Contains("error"))
                        {
                            log.Error(DateTime.Now.ToLongTimeString() + "Twitter Error : Occured in posting msg : " + PostMsg + ", Message : " + ts.Content);
                            strErrorMsg.Append(ts.Content);
                        }
                    }
                }
                catch (Exception e)
                {
                    log.Error(DateTime.Now.ToLongTimeString() + "Twitter Error : Occured in posting msg : " + PostMsg + ", Message : " + e.Message);
                    strErrorMsg.Append(e.Message);
                }
               
            
            log.Info("END Tweeting At==> " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            return MsgID;
            #endregion
        }
