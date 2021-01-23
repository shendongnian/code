    [Table("Persons", Schema="MySchema")]
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }
    [Table("Users", Schema = "MySchema")]
    partial class User : Person
    {
    }
