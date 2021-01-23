    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostback)
        {
        	string Item = ddl.SelectedItem.ToString();
        
        	if (Item == "Non-Payment")
        	{
        		tbReturn.Visible = false;
        	}
        }
    }
