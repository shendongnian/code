    protected void Page_Load(object sender, EventArgs e)
    {
        PIDVIEW = Request.QueryString["Email"];
        PIDPROF = Convert.ToInt32(PIDVIEW);
        if (!IsPostBack)
        {
            HttpContext context = HttpContext.Current;
            SearchedUser();
            imagebindGrid();
            PostSelection();
    }
