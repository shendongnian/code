    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
    {
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
        GridView1.Visible = true;
        SurgeonsLabel.Visible = false;
        NursesLabel.Visible = false;
    
        if (GridView1.Rows.Count == 0)
        {
            UnscheduledSurgery.Text = "No Surgeries had been performed on the selected date. Please select other date.";
        }
        else
        {
            UnscheduledSurgery.Text = "Surgeries performed on the selected date: ";
        }
    }
    }
