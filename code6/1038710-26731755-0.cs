    public class AddedContacts
    {
        private List<CreateContact> Contact;
        public List<CreateContact> ClassCreateContact
        {
            get { return Contact; }
            set { this.Contact = value; }
        }
        public AddedContacts()
        {
            Contact = new List<CreateContact>();
            ClassCreateContact = new List<CreateContact>();
        }
    }
