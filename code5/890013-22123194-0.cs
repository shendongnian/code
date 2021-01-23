    public static void PostMessage(string accessToken, string message)
    {
        try
        {
            FacebookClient facebookClient = new FacebookClient(accessToken);
            dynamic getAccess = new ExpandoObject();
            getAccess.access_token = accessToken;
            dynamic accessResult = facebookClient.Get("/{your facebook userID}/accounts", getAccess);
            foreach (dynamic j in accessResult.data)
            {
                if (j.name == "{Name of your facebook page}")
                {
                    accessToken = j.access_token;
                }
            }
           
            dynamic messagePost = new ExpandoObject();
            messagePost.access_token = accessToken;
            //messagePost.picture = "";
            //messagePost.link = "[SOME_LINK]";
            //messagePost.name = "[SOME_NAME]";
            //messagePost.caption = "";
            
            messagePost.message = message;
          
            messagePost.url = "{url}";            
            // this will make a photo post
            var result = facebookClient.Post("/{your page name}/photos", messagePost);
            // this will make a regular post to your feed
            facebookClient.Post("/{your page name}/feed", messagePost);
        }
        catch (FacebookOAuthException ex)
        {
             //handle something
        }
        catch (Exception ex)
        {
             //handle something else
        }
    }
