    public static void sendToParse()
        {
            
            if (count != 0)
            {
                Debug.LogError("Already exists");
            }
            else
            {
                ParseObject currentUser = new ParseObject("IdealStunts");
                currentUser["name"] = fbname;
                currentUser["email"] = fbemail;
                currentUser["fbid"] = FB.UserId;
                Task saveTask = currentUser.SaveAsync();
                Debug.LogError("New User");
            }
        }
