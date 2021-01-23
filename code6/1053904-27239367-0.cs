    public interface IUserConfig {
         int PasswordId{ get; set; }
         int UserId { get; set;}
    }
    // Constructor for CategoryRepository : ICategoryRepository 
    public CategoryRepository(DbContext context, IUserConfig)  
    {
       ....
    }
