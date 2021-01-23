    public class MySiteOracleRepository
    {
        private string ConnectionString {get; set;}
    
        public MySiteOracleRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
    
        public ApplicationUser GetUserByUsername(string username)
        {
            OracleCommand command = new OracleCommand("select firstname, lastname, username from users where username=:username");
            DataTable dt = OracleDatabaseHelper.GetDataTable(command, ConnectionString);
            ApplicationUser user = dt.AsEnumerable().Select(r => new ApplicationUser(){
                FirstName = r.Field<string>("firstname"),
                LastName = r.Field<string>("lastname"),
                Username = r.Field<string>("username")
            }).Single();
            return user;
        }
    }
