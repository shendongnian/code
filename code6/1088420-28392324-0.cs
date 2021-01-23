	interface IStorage
	{
		Func<object> Get { get; }
	}
	
	public class ManagingModel<T> : IStorage
	{
		public Func<T> Get { get; set; }
		
		Func<object> IStorage.Get
		{
			get
			{
				return () => this.Get();
			}
		}
	}
