    protected void OnAuthResponse(FBResult result)
    {
    	Dictionary<string, object> dictionary = new Dictionary<string, object>();
    	dictionary["is_logged_in"] = (object) (bool) (this.IsLoggedIn ? 1 : 0);
    	dictionary["user_id"] = (object) this.UserId;
    	dictionary["access_token"] = (object) this.AccessToken;
    	dictionary["access_token_expires_at"] = (object) this.AccessTokenExpiresAt;
    	
    	FBResult result1 = new FBResult(Json.Serialize((object) dictionary), result.Error);
    	using (List<FacebookDelegate>.Enumerator enumerator = this.authDelegates.GetEnumerator())
    	{
    		while (enumerator.MoveNext())
    		{
    			FacebookDelegate current = enumerator.Current;
    			if (current != null)
    			current(result1);
    		}
    	}
    	this.authDelegates.Clear();
    }
