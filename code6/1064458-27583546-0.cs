      protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
    {
        q_LBL.Text = "What is the right answer?";
        ArrayList options = new ArrayList();
        options.Add("a");
        options.Add("b");
        options.Add("c");
        options.Add("d");
        options.TrimToSize();
        options_RBL.DataSource = options;
        options_RBL.DataBind();
    
    }
    }
    
    protected void submit_BTN_Click(object sender, EventArgs e)
    {
        fb_LBL.Text = options_RBL.SelectedValue;
    }
