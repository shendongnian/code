    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            FillControls();   
            //Not sure why you have this here, probably not needed
            ddl_SelectedIndexChanged((DropDownList)PlaceHolder1.FindControl("ddlTurCountry"), null);
        }
        else
        {
            
        }
    }
