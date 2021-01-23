    public class Person
    {
        public int Id { get; set; }
        //will be stored in database as single string.
        public SaclarStringCollection Phones { get; set; } = new ScalarStringCollection();
    }
