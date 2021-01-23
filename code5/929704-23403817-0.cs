    [DataContract]
    public class ReturnObject // Feel free to name to something more suitable
    {
        [DataMember(Name="id")]
        public int Id {get; set;} // Int assumed
        [DataMember(Name="text")]
        public string Name {get; set;}
        [DataMember(Name="a_attr")]
        public ReturnObjectAttributes Attributes {get; set;}
    }
    
    [DataContract]
    public class ReturnObjectAttributes // Feel free to name to something more suitable
    {
        [DataMember(Name="data-extra")]
        public ExtraData ReturnObjectAttrData {get; set;}
    }
    
    [DataContract]
    public class ExtraData // Feel free to name to something more suitable
    {
        [DataMember]
        public decimal Weight{get; set;} // Decimal assumed
        [DataMember]
        public decimal MaxScore {get; set;} // Decimal assumed
    }
    
    // Then process
    data.Select(p => new ReturnObject()
    {
        Id = p.Id,
        Name = p.Name,
        Attributes = new ReturnObjectAttributes()
        {
            ExtraData = new ReturnObjectAttrData()
            {
                Weight = p.Weight,
                MaxScore = p.MaxScore
            }
    }).ToList();
