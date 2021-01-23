    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
          IEnumerable<Task> tasks = _dbc.Tasks.ToList();        
          GridView1.DataSource = tasks;
          GridView1.DataBind();
       }
    }
