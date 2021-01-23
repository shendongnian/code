    public Assignments GetAssignmentsForProider(string provider_k, string recordType)
    {
        var query = from ea in this.Context.Assignments
                    where ea.Provider_K == provider_k &&
                          ea.RecordType == recordType
                    select ea;
        if (recordType == "A")
            return query.Where(ea => ea.Active).FirstOrDefault();
        else if (recordType == "E")
            return query.FirstOrDefault();
        return null;
    }
