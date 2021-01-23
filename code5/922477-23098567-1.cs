	class MainPresenter
	{
		private IMainView _view;
		public MainPresenter(IMainView view) 
		{
			_view = view;
		}
		public void ValidateText1()
		{
			if (/* some validation is false */)
			{
				_view.ErrorMessage = "Text1 isn't valid";
			}
		}
		
		public void ValidateText2()
		{
			if (/* some validation is false */)
			{
				_view.ErrorMessage = "Text2 isn't valid";
			}
		}
	 }
