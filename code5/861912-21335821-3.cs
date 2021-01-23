    try
    {
    	if(!IsPostBack){
            ListItem defaultOption = new ListItem("---Please Select---", String.Empty);
    	    d.Items.Insert(0, defaultOption);
            defaultOption.Attributes.Add( "disabled", "disabled" );
    	}
    }
    catch (Exception ex)
    {
        Console.WriteLine("{0} Exception caught.", ex);
    }
