    /// <summary>
    /// When viewData is null, we just return null.  Otherwise, we
    ///		convert the viewData collection to a ViewDataDictionary
    /// </summary>
    /// <param name="htmlHelper">HtmlHelper provided by view</param>
    /// <param name="viewData">Anonymous view data object</param>
    /// <returns></returns>
    public static ViewDataDictionary vd(this HtmlHelper htmlHelper, object viewData)
    {
    	if (viewData == null) return null;
    
    	IDictionary<string, object> dict = viewData.ToDictionary();
    
    	//We build the ViewDataDictionary from scratch, because the
    	//	object parameter constructor for ViewDataDictionary doesn't
    	//	seem to work...
    	ViewDataDictionary vd = new ViewDataDictionary();
    	foreach (var item in dict)
    	{
    		vd[item.Key] = item.Value;
    	}
    
    	return vd;
    }
