    public class Comment
    {
        ...
    
        public Guid Product_Id { get; protected set; } // simple property
        public virtual Product Product { get; protected set; }
    }
