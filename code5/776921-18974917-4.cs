    protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
            GridView1.DataSource = rpt.Documents1s.ToList();
            GridView1.DataBind();
    
                BindGrid();
    
                MultiView1.SetActiveView(vHome);
    
                btnBacktoHome.Visible = false;
                lblStatus.Visible = false;
            }
    
        }
