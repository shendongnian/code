    protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.Items.Add("Home");
            DropDownList1.Items.Add("Login");
            DropDownList1.Items.Add("Signup");
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sUrl = DropDownList1.SelectedItem.Text + ".aspx";
            Response.Redirect(sUrl);
        }
