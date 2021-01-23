    public int a;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
          a = 25;
          DataBind();
       }
    }
