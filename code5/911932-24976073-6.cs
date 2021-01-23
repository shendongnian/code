    public class A
    {
        public int ID { get; set; }
    }
    public class B
    {
        public int ID { get; set; }
    }
    public class AToB
    {
        // Composite primary key
        [Key]
        public int IdA { get; set; }
        [Key]
        public int IdB { get; set; }
        public A SideA { get; set; }
        public B SideB { get; set; }
        // An additional property in the many-to-many join table
        public DateTime Created {  get; set; }
    }
