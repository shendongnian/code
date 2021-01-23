    [DataContract]
    public class Item
    {
        private string firstName= "";
        private string secondName= "";
        [DataMember(Name = "First Name")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName= value; }
        }
        [DataMember(Name = "Second Name")]
        public string SecondName
        {
            get { return secondName; }
            set { secondName= value; }
        }
    }
