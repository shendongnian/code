    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id;
            if(int.TryParse(Request.QueryString["id"], out id)
            {
            
                GridView1.DataSource = DataRepository.GetG1(id);
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = DataRepository.GetG1();
                GridView1.DataBind();
            }
        }
    }
