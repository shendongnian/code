    public class Obj1
    {
        public Obj1
        {
            Froms = new List<Obj2>();
            Tos = new List<Obj2>();
        }
        [Key]
        public int ID { get; set;}
        public string name { get; set; }
        [InverseProperty("From")]
        public virtual ICollection<Obj2> Froms { get; set; }
        [InverseProperty("To")]
        public virtual ICollection<Obj2> Tos { get; set; }
    }
    public class Obj2
    {
        [Key]
        public int ID { get; set; }
        public int quantity { get; set; }
        public int FromID { get; set; }
        [ForeignKey("FromID")]
        public virtual Obj1 From { get; set; }
        public int ToID { get; set; }
        [ForeignKey("ToID")]
        public virtual Obj1 To { get; set; }
    }
