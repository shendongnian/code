        void FBConnect(){
			if(!FB.IsInitialized){
				Debug.Log("Initializing FB");
				FB.Init(FBInitCallback, null,null);
			} else {
				Debug.Log("No need for FB init");
				FBInitCallback();		
			}
		}
		private void FBInitCallback(){
			Debug.Log("FB init OK");
			if(!FB.IsLoggedIn){
				FB.Login("email,user_friends", FBLoginCallback);
			} else {		
				//GetHisFBDataNow();
				Debug.Log("Everything is known about this guy");
			}
		}
		private void FBLoginCallback(FBResult result){
			if (result.Error != null){
				Debug.Log("FB Error Response:\n" + result.Error);
			} else if (!FB.IsLoggedIn)		{
				Debug.Log("FB Login cancelled by Player");
			} else {
				//GetHisFBDataNow();
				Debug.Log("Now also everything is known about this guy");
			}
		}
