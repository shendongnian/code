    public static class MyContextFactory
    {
		public static MyContext GetContext() {
			IConfiguration configuration = new Configuration().AddJsonFile("config.json");
			return new MyContext(configuration["Data:DefaultConnection:ConnectionString"]);
		}
    }
