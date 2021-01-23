    public class Foo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    
        public virtual string Name { get; set; }
    }
