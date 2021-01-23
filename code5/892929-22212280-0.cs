    public class Foo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int displayID { get; set; }
    
        [Key]
        public int myKey { get; set; }
    
    }
