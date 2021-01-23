    public static void CloseForm()
    {
    	if (loadingscreen == null)
    	{
    		_thread.Abort();
    		return;
    	}
    	loadingscreen.Invoke(new CloseDelegate(CloseFormInternal));
    }
