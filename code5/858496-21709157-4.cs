    public class PersonCombined
    {
        public Person Person { get; set; }
        public Address DefaultAddress { get; set; }
        public Contact EmailContact { get; set; }
        public Contact PhoneContact { get; set; }
        public Contact WebsiteContact { get; set; }
    }
    public class Person : IWebServiceModel
    {
        public int ID { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonDescription { get; set; }
        public Nullable<bool> PersonIsActive { get; set; }
    }
 
