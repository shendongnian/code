    public class LoginPersonConfiguration : EntityTypeConfiguration<LoginPerson>
    {
        public LoginPersonConfiguration()
        {
            ToTable("LoginPerson");
            HasKey(l => l.Id);
            HasRequired(l => l.Person).WithOptional(p => p.LoginPerson).Map(t => t.MapKey("PersonId")); 
        }
    }
