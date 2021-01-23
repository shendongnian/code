	private addNew _addNew { get; set; }
	public newdetails(addNEw parent)
	{
		InitializeComponent();
		_addNew = parent; 
	}
	//you can access any public variable at addNew form with:
	int test = _addNew.PublicVariableName
