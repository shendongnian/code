    public class MyContext : DbContext {
        public MyContext(string connectionString) : base(connectionString) {
		}
    }
    var context = new MyContext("myConnectionString");
