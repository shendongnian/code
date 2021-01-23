    [DataContract]
    public class BaseClass
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember(Name = "_x003C_SecondName_x003E_k__BackingField")]
        public string SecondName { get; set; }
        
    }
