    public class ClientCompany
    {
        // .... 
        public virtual ISet<ContactPerson> ContactPeople { get; set; }
        public virtual AddPerson(ContactPerson person)
        {
            ContactPeople = ContactPeople ?? new HashSet<ContactPerson>();
            ContactPeople.Add(person);
            person.ClientCompany = this;
        }
    }
