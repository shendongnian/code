    [DataContract]
    public class TableWrapper{
        [DataMember(IsRequired=false)]
        public Table Table{get;set;}
    }
    [OperationContract]
    [ServiceKnownType(typeof(SubTable))]
    float GetValue(TableWrapper tableWrapper);
    if  (tableWrapper.Table!= null)
        var result = proxyGetValue(tableWrapper.Table);
    else
        var result = proxyGetValueWhenNull();
