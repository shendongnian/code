    var fb - new FacebookClient(this.loginButton.CurrentSession.AccessToken);
    fb.GetTaskAsync
    (
        "fql",
        new
        { 
            q = "SELECT uid, name, pic_square FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = me() LIMIT 25)" 
        }
    ).ContinueWith
    (
        t=> 
        if(!t.IsFaulted) 
        {
            dynamic result = t.Result;
            System.Diagnostics.Debug.WriteLine("Result: " + result.ToString());
        }
    );
