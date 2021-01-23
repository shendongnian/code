    public class PropUser
    {
        public PropUser
        {
            Product = new PropProduct();
        }
        public int UserId { get; set; }
    
        public int ParentId { get; set; }
    
        public PropProduct Product { get; set; }
    }
