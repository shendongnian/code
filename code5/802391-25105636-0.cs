    protected void Button1_Click(object sender, EventArgs e)
    {
        string value = TextBox1.Text;
        Session["value"] = value;
        Response.Redirect("~/Sessionpage.aspx");
    }
