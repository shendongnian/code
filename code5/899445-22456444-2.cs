	public class NoDataViewModel : DocumentViewModel
	{
		public NoDataViewModel(IEventAggregator eventAggregator,
			IViewModelFactory viewModelFactory)
			: base(viewModelFactory, eventAggregator, )
		{
		}
		public override void Save()
		{
			// nothing to do
		}
		public override void Reload()
		{
			// nothing to do
		}
	}
	public class NoDataViewModelMock : NoDataViewModel
	{
		private static int activationCounterForTesting = 0;
		private static int deactivationCounterForTesting = 0;
		public static int ActivationCounterForTesting
		{
			get
			{
				return activationCounterForTesting;
			}
		}
		public static int DeactivationCounterForTesting
		{
			get
			{
				return deactivationCounterForTesting;
			}
		}
		public NoDataViewModelMock()
			: base(null, null)
		{
		}
		protected override void OnActivate()
		{
			activationCounterForTesting++;
			base.OnActivate();
		}
		protected override void OnDeactivate(bool close)
		{
			deactivationCounterForTesting++;
			base.OnDeactivate(close);
		}
	}
