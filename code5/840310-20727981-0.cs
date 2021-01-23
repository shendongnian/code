    public class Parent
        {
            public int Id { get; set; }
            //other properties in parent class....
            public virtual ICollection<ContentType> ContentTypes  { get; set; }
        }
    
        public class ContentType
        {
            public int Id { get; set; }
            //other properties...
            public int ParentId { get; set; }//..this will help us to define the relationship in fluent API
            public Parent Parent { get; set; }
        }
