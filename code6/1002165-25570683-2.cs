    public void LoadUserInfo()
    {
        FacebookClient fb = new FacebookClient(App.AccessToken);
        fb.GetCompleted += (o, e) =>
        {
            /*yadda mfing blah */
            using (FacebookDataContext db = new FacebookDataContext(DBConnectionstring))
            {
                db._fbcontacts.InsertOnSubmit(new FacebookContactsList { Name = FBName });
                db.SubmitChanges();
            }
        };
        fb.GetTaskAsync("me");
    }
