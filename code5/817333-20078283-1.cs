    public class UserMap : EntityTypeConfiguration<User>
    {
    
      public UserMap()
      {
         HasOptional(x=>x.Country);
      }
    
    }
