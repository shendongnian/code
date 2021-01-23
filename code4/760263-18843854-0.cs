        [Table("Persons", Schema="Wms")]
        public partial class Person
        {
                public int PersonId { get; set; }
                public string Name { get; set; }
        }
        [Table("Users", Schema = "Wms")]
        partial class Users : Location
        {
        }
