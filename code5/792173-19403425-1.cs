    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)  // you do not want to handle this 
        //{                      // otherwise your panels will only hide on first load
            pan1.Visible = false; //this is required to reset the visibility of the panel back
            pan2.Visible = false; //this is required to reset the visibility of the panel back
        //}   
    }
    protected void lnk1_Click(object sender, EventArgs e)
    {
        pan1.Visible = true;
    }
    protected void lnk2_Click(object sender, EventArgs e)
    {
        pan2.Visible = true;
    }
