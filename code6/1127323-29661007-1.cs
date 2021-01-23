    public bool UserLogin(string username, string pass){
    
        return ParseUser.LogInAsync(username, pass).ContinueWith(t =>
                                                          {
            if (t.IsFaulted || t.IsCanceled)
            {
                Debug.Log ("User do not exists");
                return false;
            }
            else
            {
                Debug.Log ("User exists");
                return true;
            }
        }).Result;       
    } 
