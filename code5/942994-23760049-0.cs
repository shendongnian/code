    public Assignments GetAssignmentsForProider(string provider_k, string recordType)
    {
        var query = from ea in this.Context.Assignments
            where ea.Provider_K == provider_k
                    && ea.RecordType == recordType
                    && (recordType == "E" ? true : ea.Active)
                select ea;
            return query.FirstOrDefault();
    }
