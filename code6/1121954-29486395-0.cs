    public class Person {
        public int Id { get; set; }
    }
    public class Passport {
        [Key]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        [Index(IsUnique=true)]
        public string PassportId { get; set; }
    }
