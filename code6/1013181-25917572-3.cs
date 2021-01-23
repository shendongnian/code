    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
 
        [Column(Name="Gender")]
        public int InternalGender { get; set; }
        [NotMapped]
        public Gender Gender
        {
           get { return (Gender)this.InternalGender; }
           set { this.InternalGender = (int)value; }
        }
    }
