    private void GetFeed()
            {
                object obj;
                Facebook.JsonObject jsonObj;
                Facebook.JsonObject jsonPaging;
                FacebookClient client;
                int pageCount = 0;
                string access_token;
                string URL;
                DateTime fetchFaceBookFeedFromDate;
                DateTime? oldestPostFetched = null;
    
                fetchFaceBookFeedFromDate = DateTime.Now.AddDays(-30);
                access_token = ConfigurationManager.AppSettings["FacebookPageAccessToken"].ToString();
                URL = "/" + ConfigurationManager.AppSettings["FacebookPageId"].ToString() + "/feed";
    
                client = new FacebookClient(access_token);
    
    
                while (URL.Length > 0 && pageCount < 1000)
                {
                    if ((obj = client.Get(URL)) != null)
                    {
                        if ((jsonObj = obj as Facebook.JsonObject) != null && jsonObj.Count > 0)
                        {
                            if (jsonObj[0] is Facebook.JsonArray)
                                oldestPostFetched = SaveFacebookForumThread(jsonObj[0] as Facebook.JsonArray, fetchFaceBookFeedFromDate);
    
                            if (jsonObj.Keys.Contains("paging") && (jsonPaging = jsonObj["paging"] as Facebook.JsonObject) != null && jsonPaging.Keys.Contains("next"))
                                URL = jsonPaging["next"].ToString();
                            else
                                break;
                        }
                    }
                    pageCount++;
    
                    if (oldestPostFetched.HasValue && fetchFaceBookFeedFromDate > oldestPostFetched)
                        break;
                }
            }
