    public Boolean saveParty(Party ptObj)
    {
        string query1 = "EXEC insertToParty @Id, @Name, etc";
        
        Dictionary<string, object) p = new Dictionary<string, object>();
        p.Add("@Id", ptObj.PTReqID);
        p.Add("@Name", ptObj.PTName);
        // etc.
        
        return (new DataAccessLayer().executeNonQueries(query1));
    }
