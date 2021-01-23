    public class Customers
        {   
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public long Sessionid { get; set; }
            public long? Pers { get; set; }
        }
