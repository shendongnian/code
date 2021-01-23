          void start()
          {
            StartCoroutine(retrieveHighscores()); //Start out by getting the current scores.
          }
         
        IEnumerator retrieveHighscores()
	   {
		var form = new WWWForm(); // create a new form
	
	
		form.AddField("Nipun",name); // add the data you want to retrieve in the form fields
		var rawData = form.data;
		var headers = form.headers;  // here headers will be used to authenticate the credentials of the person trying to access
		headers["Authorization"]="Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("username:password"));
		
		WWW webRequest = new WWW("https://abc.com/test.php", rawData, headers); // 
		yield return webRequest;
		if (webRequest != null) {
      //here you have successfully got the response back from the server , here i am adding the whole response in a string and then splitting the string based on the format of the data i received.
						string x = webRequest.text;
						string[] lines = webRequest.text.Split(new string[] { System.Environment.NewLine }, System.StringSplitOptions.RemoveEmptyEntries); //Split the response by newlines.
			Debug.Log(x); // to check what you received
						scores = new Dictionary<string, int>(); //Always reset our scores, as we just got new ones.
						foreach (string line in lines) //Parse every line
						{
							// code here how you want to use the split up data you received
						}
				}
		else
			Debug.Log("error");
	}
}
