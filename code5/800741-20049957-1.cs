            var accessToken = TempData["accessToken"] as string;
            if (string.IsNullOrEmpty(accessToken))
            {
                //if access token is null or user is not logged in, redirect to home controller
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var fb = new Facebook.FacebookClient(accessToken);
                var me = fb.Get("me") as Facebook.JsonObject;  //current logged user
                var userFacebookId = me["id"].ToString();
