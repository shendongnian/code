    [DataContractAttribute]//This tells the EZ_Iso dll that this object is serializable 
    public PageOneCache{
    
        [DataMember] //This tells the serializer to serialize this member
        public bool flag1 {get; set;}
    
        [DataMember]
        public List<int> ages {get;set;}
    
        public int boxes {get; set;} // This member doesn't have the [DataMember] so it wont get saved
    }
