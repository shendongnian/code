    protected void Page_Load(object sender, EventArgs e)
        {
    		if ( IsPostBack ) //don't forget :)
    			return;
        }
    
    	protected void Dropdownlist1_SelectedIndexChanged( object sender, EventArgs e )
    	{
    		if ( Dropdownlist1.SelectedValue == "1" ) //Gym item selected
    		{
    			multiView.ActiveViewIndex = 0; //Gym view active
    		}
    	}
