	public class ViewModel<TModel>
	{
		public TModel Model { get; private set; }
	
		public static ViewModel<T> CreateFromObject<T>(T model)
			where T : INotifyPropertyChanged
		{
			return new ViewModel<T>(model);
		}
		
		public static ViewModel<T> CreateFromCollection<T>(T model)
			where T : INotifyCollectionChanged
		{
			return new ViewModel<T>(model);
		}
		
		private ViewModel(TModel model)
		{
			this.Model = model;
		}
	}
