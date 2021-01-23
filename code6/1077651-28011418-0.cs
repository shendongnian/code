     public class ApplicationDbContext : DbContext 
      {
         public ApplicationDbContext()
             : base("DefaultConnection")
         {
         }
     
         public static ApplicationDbContext Create()
         {
             return new ApplicationDbContext();
         } 
      }
