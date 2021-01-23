    struct DBRecord
    {
    public string id
    public string name {get;set;}
    public string address {get;set;}
    public string type {get;set;}
    }
    //Selection:
    List<DBRecord> aList = typeList.FindAll(p => ((DBRecord)p).type == "A");
    
    List<DBRecord> bList = typeList.FindAll(p => ((DBRecord)p).type == "B");
