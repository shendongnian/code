    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            ToTable("People");
            HasKey(p => p.PersonId);
            Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(p => p.User).WithRequired(u => u.Person); // User is option here but
                                                                  // Person is required in User
        }
    }
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
 
            ToTable("Users");
            HasKey(u => u.UserId);
            Property(u => u.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // Create a unique index in the Users table on PersonId
            Property(u => u.PersonId).IsRequired().HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("IX_PersonId") { IsUnique = true }));
         }
    }
