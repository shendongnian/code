    protected void Page_Load(object sender, EventArgs e)
    {
       string pwd = txtPwd.Text;
       txtPwd.Attributes.Add("value", pwd);
    }
