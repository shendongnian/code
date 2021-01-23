    using SimpleJSON;
    public YourClass : MonoBehaviour{
        public delegate void WWWCalback(WWW wwwData);
        private void answersCallback(WWW wwwData){
            JSONNode questionJSON = JSONNode.Parse (wwwData.text);
            Question q = new Question();
            q.Id = questionJSON["id"];
            q.Answere = questionJSON["Answere"];
        }
        private void getAnswers(){
          StartCoroutine(GetQuestion(answersCallback));
        }
        IEnumerator GetQuestion(WWWCalback callback){
          string input = new QuestionThemeRequest(){ QuestionTheme = "BAJS" }.ToString();
          Hashtable headers = new Hashtable();
          headers.Add("Content-Type", "application/json");
          byte[] body = Encoding.UTF8.GetBytes (input);
          WWW www = new WWW ("http://localhost:52603/api/Question/GetRandomQuestionByTheme", body, headers);
          yield return www;
          if((!string.IsNullOrEmpty(www.error))) {
				print( "Error downloading: " + www.error );
		  } else {
				callback(www);
		  }
        }
    }
