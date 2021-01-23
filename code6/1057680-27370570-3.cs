    [WebMethod]
    public string Update(string itemId, string voteType)
    {
       //put ADO.net here
       return success ? votePostSuccess : votePostError;
    }
