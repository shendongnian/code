    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback)
        {
            if (this.Session["value1"] != null)
            {
                lbl1.Text = (String)this.Session["value1"].ToString();
            }
        }
    }   
