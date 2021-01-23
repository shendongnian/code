    using SimpleJSON;
    IEnumerator GetQuestion(){
        string input = new QuestionThemeRequest(){ QuestionTheme = "BAJS" }.ToString();
        Hashtable headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        byte[] body = Encoding.UTF8.GetBytes (input);
        WWW www = new WWW ("http://localhost:52603/api/Question/GetRandomQuestionByTheme", body, headers);
        yield return www;
        if((!string.IsNullOrEmpty(wwwData.error))) {
		   print( "Error downloading: " + wwwData.error );
		} else {
		   JSONNode questionJSON = JSONNode.Parse (www.text);
           Question q = new Question();
           q.Id = questionJSON["id"];
           q.Answere = questionJSON["Answere"];
		}
    }
