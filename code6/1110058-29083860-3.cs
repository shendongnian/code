	public class DataServiceFactory {
		public DataServiceFactory(MyDbContext context)
		{
			Context = context;
		}
		internal MyDbContext Context { get; private set; }
		private TService Create<TService>() where TService : MyDbContext , new()
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
    ...
