	class Application
	{
		public int ID { get; set; }
		public string AuthKey { get; set; }
		// and so on
	}
	interface IApplicationRepository
	{
		IEnumerable<Application> GetAll();
		void Update(Application app);
		void Delete(Application app);
		void Insert(Application app);
	}
	interface IUnitOfWork : IDisposable
	{
		IApplicationRepository Applications { get; }
		void Commit();
	}
