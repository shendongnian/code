    [System.Web.Http.HttpGet]
    public AjaxAnswer BatchUserCreate(string email, string names) {
        string[] emaillist = email.Split('\n');
        string[] nameslist = names.Split('\n');
    
        // You should declare "newId" if you want to return it via "new AjaxAnswer(newId)" 
        int newId = 0;
        // if emaillist and nameslist have diffrent lengths 
        // let's take minimal length
        int n = Math.Min(nameslist.Length, emaillist.Length);
     
        for (int i = 0; i < n; ++i) {
          db.AddParameter("@email", emaillist[i]);
          db.AddParameter("@name", nameslist[i]);
          newId = db.ExecuteScalar(userInsQuery);
        }
    
        return new AjaxAnswer(newId);
    }
