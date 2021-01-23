    public class Person
    {
        public int id { get; set; }
        // rest of the fields here
        public virtual ICollection<Pet> Pets { get; set; }
    }
    
    public class Pet
    {
        [DisplayName("Belongs to:")]
        public int person_id { get; set; }
        // Rest of the fields here
        public virtual Person Owner { get; set; }
    }
