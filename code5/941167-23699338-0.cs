    [DataContractAttribute]
    public class MainPageSettings
    {        
        [DataMember]         
        publicString yourSetting1 {get; set;}
        [DataMember]         
        public List<Object> yourSetting2 {get; set;}
        [DataMember]         
        public int yourSetting3 {get; set;}
        [DataMember]         
        public Boolean yourSetting4 {get; set;}
    }
