     FacebookClient fb = new FacebookClient(App.AccessToken);
     fb.GetCompleted += (o, e) =>
     {
    	 var result = (IDictionary<string, object>)e.GetResultData();
    	 var FBName = String.Format("{0} {1}", (string)result["first_name"], (string)result["last_name"]);
    	 using (FacebookDataContext db = new FacebookDataContext(DBConnectionstring))
    	 {
    		db._fbcontacts.InsertOnSubmit(new FacebookContactsList { Name = FBName }); 
    		db.SubmitChanges();
    	 }
     };
     fb.GetTaskAsync("me");
