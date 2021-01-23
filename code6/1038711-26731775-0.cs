    public class AddedContacts
    {
        private List<CreateContact> Contact = new List<CreateContact>();
        public List<CreateContact> ClassCreateContact
        {
            get { return Contact; }
            set { this.Contact = value; }
        }
    }
