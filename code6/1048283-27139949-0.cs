    public class SomeConsumer : IConsumer
    {
		private readonly IPresenter presenter;
	
		public SomeConsumer(IPresenter presenter)
		{
		    if (presenter == null)
				throw new ArgumentNullException("presenter");
			this.presenter = presenter;
		}
		
		public void DoSomething()
		{
		    this.presenter.Present();
		}
    }
