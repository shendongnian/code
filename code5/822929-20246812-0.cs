	public class IncrementalLoadingCollection<T> : ObservableCollection<T>, ISupportIncrementalLoading 
	{
		// todo; write a lot of magic here.(VIEW)
	}
	// IN PCL
	public abstract class PortableFactory
	{
		private static PortableFactory _factory;
		public static PortableFactory Current
		{
			get
			{
				if (_factory == null)
				{
					throw new InvalidOperationException();
				}
				return _factory;
			}
			set
			{
				_factory = value;
			}
		}
		protected PortableFactory() {
		   // note we auto-set current here,
		   // which saves an extra step for the caller
			Current = this;            
		}
		public abstract IList<T> GetIncrementalCollection<T>();
	}
	// IN XAML APP
	public partial class App : Application
	{
		private PortableFactory _pf = new WPFPortableViewFactory();
		private class WPFPortableViewFactory : PortableFactory
		{
			public override IList<T> GetIncrementalCollection<T>()
			{
				return new IncrementalLoadingCollection<T>();
			}
		}
	}
	// IN VIEWMODEL
	public class ViewModel
	{
		public IList<Car> Cars { get; set; }
		public ViewModel()
		{
			Cars = PortableFactory.Current.GetIncrementalCollection<Car>();
		}
	}
