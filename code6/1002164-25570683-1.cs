     public void LoadUserInfo()
     {
         FacebookDataContext db = new FacebookDataContext(DBConnectionstring);
         FacebookClient fb = new FacebookClient(App.AccessToken);
         fb.GetCompleted += (o, e) =>
         {
             try
             {
                 /*blah fricken blah snipped */
                 db.SubmitChanges();
             }finally{
                 if(db != null) db.Dispose();
             }
         };
         fb.GetTaskAsync("me");
     }
