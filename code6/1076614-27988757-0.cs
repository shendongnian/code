    public string GetQuestion(){
        string input = new QuestionThemeRequest(){ QuestionTheme = "MyRequest" }.ToString();
        Debug.Log (input.ToString());
        Hashtable headers = new Hashtable();
        headers.Add("Content-Type", "application/json");
        Debug.Log (headers.ToString ());
        byte[] body = Encoding.UTF8.GetBytes (input);
        WWW www = new WWW ("http://localhost:52603/api/Question/GetRandomQuestionByTheme", body,     headers);
        yield return www;
        if(www.error != null){
             Debug.Log(www.error);
        }
        return "HEJSAN";
}
