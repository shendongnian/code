    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Master.myText = testTextBox.Text;
        Response.Redirect("~/Page2.aspx?val=" + testTextBox.Text);
    }
