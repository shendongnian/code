	var someobj = new SomeObj(); 
	private void OnButtonClick(...)
	{
		DoWork();
	}
	
	var a = new object();	
	private void DoWork()
	{
		lock(a) {
		    try {
			    someobj.DoSomething();
			    someobj = null;
			    DoEvents();				
			}
			finally
			{
			    someobj = new SomeObj();
			}
		}	
    }
