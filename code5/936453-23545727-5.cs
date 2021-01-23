    protected void Page_Load(object sender, EventArgs e)
    {
        //the better way, using a repeater
        TheBetterWay();
    }
    
    private void TheBetterWay()
    {
        //bind the repeater to an array of three elements
        rptSpeciality.DataSource = new object[] { null, null, null };
        rptSpeciality.DataBind();
    }
