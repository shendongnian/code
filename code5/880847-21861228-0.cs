    public class RawData
    {
    
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Item1 i1 {get;set;}
        public virtual Item2 i2 {get;set;}
        public virtual Item3 i3 {get;set;}
        //other properties
    }
