    interface IForm : IDisposable
    {
    	Form Parent { get; set; }
    	string ScreenNameLong { get; set; }
    	string ScreenTitle { get; set; }
    	void SetupForm();
    }
