	public View()
	{
	  //Instantiating the object to ExtendedViewHelper
	  viewHelper = new ExtendedViewHelper(this);
	  //Calling method from class ViewHelper
	  viewHelper.OnButtonClicked();
	  //and from ExtendedViewHelper
	  viewHelper.OnSecondBtnClicked();
	}
	//OldViewHelper Constructor
	public ViewHelper(View tempForm, OldFunctionalityService oldService)
	{
		 xForm = tempForm;
		 xService = oldService;
	}
	//First Button Implementation Code
	public void OnButtonClicked()
	{
		xService.DoStuff();
	}
	//NewViewHelper Constructor
	public ViewHelper(View tempForm, OldFunctionalityService oldService, NewFunctionalityService newService)
	{
		 xForm = tempForm;
		 xService = oldService;
		 xNewService = newService;
	}
	//Second Button Implementation Code
	public void OnSecondBtnClicked()
	{
		xNewService.DoStuff();
	}
