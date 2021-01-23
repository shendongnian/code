	public class Presenter1 : IPresenter
	{
		public void Present()
		{
		    // Do something here
		}
	}
	
	public class Presenter2 : IPresenter
	{
		public void Present()
		{
		    // Do something here
		}
	}
	
	public class Presenter3 : IPresenter
	{
		public void Present()
		{
		    // Do something here
		}
	}
	public class CompositePresenter : IPresenter
	{
		private readonly IPresenter[] presenters;
		
		public CompositePresenter(IPresenter[] presenters)
		{
			if (presenters == null)
				throw new ArgumentNullException("presenters");
			this.presenters = presenters;
		}
		
		public void Present()
		{
            // Do nothing except delegate the call to the nested
            // instances. You may need to do some extra work to deal
            // with multiple return values, like add up the values
            // or decide which value works best for the scenario.
			foreach (var presenter in this.presenters)
			{
				presenter.Present();
			}
		}
	}
	
