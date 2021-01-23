    <connectionStrings>
        <add name="MySailorContext" connectionString="Data Source=THOMAS-LAPTOP;Initial Catalog=MySailor;Integrated Security=True;Pooling=False;MultipleActiveResultSets=true" providerName="System.Data.SqlClient"/>
    </connectionStrings>
    
    public class MyDbContext : IdentityDbContext<MyUser, UserClaim, UserSecret, UserLogin, Role, UserRole>
    {
        public MyDbContext() : base("MySailorContext") { }
    }
