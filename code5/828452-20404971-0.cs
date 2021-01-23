    public class MyProjectRegistry : Registry
    {
		public MyProjectRegistry()
		{
			For<CardGame.DataAccess.IUnitOfWork>().Use(new CardGame.EntityFrameworkProvider.EntityFrameworkUnitOfWork("MyConnectionString"));
		}
    }
