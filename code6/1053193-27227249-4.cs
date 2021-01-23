	public class Presenter1 : IPresenter
	{
		public Presenter1(IPresenter innerPresenter)
		{
			if (innerPresenter == null)
				throw new ArgumentNullException("innerPresenter");
			this.innerPresenter = innerPresenter;
		}
	
		public void Present()
		{
		    // Do something here
			
			// You could make this call conditional
			this.innerPresenter.Present();
			
			// Or do something here
		}
	}
	
	public class Presenter2 : IPresenter
	{
		public Presenter2(IPresenter innerPresenter)
		{
			if (innerPresenter == null)
				throw new ArgumentNullException("innerPresenter");
			this.innerPresenter = innerPresenter;
		}
	
		public void Present()
		{
		    // Do something here
			
			// You could make this call conditional
			this.innerPresenter.Present();
			
			// Or do something here
		}
	}
	
	public class Presenter3 : IPresenter
	{
		public Presenter3(IPresenter innerPresenter)
		{
			if (innerPresenter == null)
				throw new ArgumentNullException("innerPresenter");
			this.innerPresenter = innerPresenter;
		}
	
		public void Present()
		{
		    // Do something here
			
			// You could make this call conditional
			this.innerPresenter.Present();
			
			// Or do something here
		}
	}
	
	public class NullPresenter : IPresenter
	{
		public void Present()
		{
		    // Do nothing here - this class is a placeholder
			// in case you want to expand the design later
		}
	}
	
