	public class DataServiceFactory {
		public DataServiceFactory(MyDbContext context)
		{
			Context = context;
		}
		internal MyDbContext Context { get; private set; }
		private TService Create<TService>() where TService : DataService , new()
		{
			TService service = new TService();
			service.Factory = this;
			return service;
		}
		public NominationService NominationService
		{
			get
			{
				return Create<NominationService>();
			}
		}
		public MetricService MetricService
		{
			get
			{
				return Create<MetricService>();
			}
		}
		... etc ...
	}
	public abstract class DataService
	{
		private DataServiceFactory _factory;
		public DataServiceFactory Factory
		{
			set
			{
				_factory = value;
			}
		}
		protected MyDbContext
		{
			get
			{
				return _factory.Context;
			}
		}
		protected DataServiceFactory Services
		{
			get
			{
				return _factory;
			}
		}
	}
