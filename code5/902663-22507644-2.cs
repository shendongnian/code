    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadData(); //if you did this without checking IsPostBack, you'd rebind the GridView and lose the existing rows
        }
    
    protected void LoadData()
    {
        //bind GridView etc
    }
