    int[] values = null;
    
    var enumerator = values.GetEnumerator();
    try
    {
    	while (enumerator.MoveNext())
    	{
    		var i = enumerator.Current;
    		// ...
    	}
    }
    finally
    {
    	var disposable = enumerator as IDisposable;
    	if (disposable != null)
    	{
    		disposable.Dispose();
    	}
    }
