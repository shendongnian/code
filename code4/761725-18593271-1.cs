    [DataContract]
    public class ClsUser
    {
        string name;
        string lastname;
        public ClsUser(string name, string lastname)
        {
            this.name = name;
            this.lastname = lastname;
        }
         [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
         [DataMember]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
    }
