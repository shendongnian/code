    public partial class User : IEntity
    {
        public int Id { get; set; }
    
        [StringLength(50)]
        public string Name { get; set; }
    }
    
    public partial class BlogPost : IEntity
    {
        public int Id { get; set; }
    
        [StringLength(50)]
        public string Title { get; set; }
    }
    public interface IEntity
    {
        int Id { get; }
    }
