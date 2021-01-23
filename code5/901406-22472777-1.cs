    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["FirstName"] = txtfName.Text;
        Session["SecondName"] = txtlName.Text;
        Response.Redirect("WebForm2.aspx");
    }
