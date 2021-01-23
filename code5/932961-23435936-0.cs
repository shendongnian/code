    public class IRelateToAnotherClass
    {
        public int Id { get; set; } // primary key
        public virtual ICollection<IGetRelatedToByAnotherClass> { get; set; }
    }
    public class IGetRelatedToByAnotherClass
    {
        public int Id { get; set; } // primary key
        public int IRelateToAnotherClassId { get; set; } // foreign key
        public virtual IRelateToAnotherClass IRelateToAnotherClass { get; set; }
    }
