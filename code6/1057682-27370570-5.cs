    [WebMethod]
    public string Savevote(string itemId, string voteType)
    {
       //put ADO.net here
       return success ? votePostSuccess : votePostError;
    }
