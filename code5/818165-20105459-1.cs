    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            if (Session["fstName"] != null)
            {
                string a = Session["fstName"].ToString();
                txtBox.Text = a;
            }
    }
