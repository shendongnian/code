    public Assignments GetAssignmentsForProider(string provider_k, string recordType)
    {
        var query = from ea in this.Context.Assignments
                    where ea.Provider_K == provider_k
                    select ea;
    
        if (recordType == "A")
        {
           query = from q in query
                   where q.Active == true
                      && q.RecordType == "A"
                   select q;
        }
        else if (recordType == "E")
        {
           query = from q in query
                   where q.RecordType == "E"
                   select q;    
        }
    
        return query;
    }
