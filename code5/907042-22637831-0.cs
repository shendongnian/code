    [System.Web.Http.HttpGet]
    public AjaxAnswer BatchUserCreate(string email, string names) {
        string[] emaillist = email.Split('\n');
        string[] nameslist = names.Split('\n');
        for(int i = 0; i!=emaillist.Length; ++i) {
            db.AddParameter("@email", emaillist[i]);
            db.AddParameter("@name", nameslist.Length > i ? nameslist[i] : "No name");
            int newId = db.ExecuteScalar(userInsQuery);
        }
        return new AjaxAnswer(newId);
    }
