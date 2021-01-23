    //Recovering session variable
            var sessionValue = Session["SexValue"];
            //Check if exist the session variable
            if (sessionValue != null)
            {
                //Parse the session variable to string
                string value = (string)sessionValue;
                //Do your stuff here
                //.................
                //.................
                //Clean the session variable
                Session.Clear();
            }
