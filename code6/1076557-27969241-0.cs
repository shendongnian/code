    public class Product
    {
        public int Id { get; set; }
      
        public int? ParentId { get; set; }
       
        public virtual Product Parent { get; set; }
    }
