    public static string EditForm(this HtmlHelper helper)
    {
       var model = helper.ViewData.Model;
       var dataType = model
    		.GetType()
    		.GetProperty("Description")
    		.GetCustomAttribute<DataTypeAttribute>()
    		.DataType;
    	...
    }
