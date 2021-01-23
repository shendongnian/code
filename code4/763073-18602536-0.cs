    public List<MyBaseClass> Objects = new List<MyBaseClass>();
    protected void Page_Load(object sender, EventArgs e)
    {
        Objects = (List<MyBaseClass>) HttpContext.Current.Items["Objects"];
    }
