    [DataContract]
    public class GroupDto
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name{ get; set; }
        [DataMember]
        public List<UserDTO> Users { get; set; }      
    }
