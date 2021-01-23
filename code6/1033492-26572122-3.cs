     [Table("ClinicProfile")]
        public class ClinicProfile
        {
            [Key]
            [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
    
            //[ForeignKey("ContactData")] here the wrong place
            public int ContactDataId { get; set; }
            [ForeignKey("ContactDataId")] // here the correct place
            public ContactData ContactData { get; set; }
        }
    
        [Table("ContactData")]
        public class ContactData
        {
             [Key]
             [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
             public int Id { get; set; }
    
             ...
        }
