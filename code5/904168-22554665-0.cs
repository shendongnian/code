    public class Person : IEntity
    {
        [key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public Person() { }
        public Person(string firstName, string surname)
        {
            FirstName = firstName;
            Surname = surname;
        }
    }
