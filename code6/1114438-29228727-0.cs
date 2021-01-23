    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        // Hide default constructor, we only want users going to the 
        // factory method
        private Person() { }
        // Factory method
        public static Person CreatePerson(int id)
        {
            // make database call and populate Person properties from id
            // parameter
            // Need to think how context is created...
            var x = context.GetPersonDetails(id);
            return new Person {
                Id = id,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone
            }
        }
    }
