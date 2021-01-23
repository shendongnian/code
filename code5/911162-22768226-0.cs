    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        string vacations = Session["vacations"] as string; // this line
        string classes = Session["vacations"] as string;
        Response.Redirect("Summary2.aspx?vacations=" + vacations + "&classes=" + classes);
    }
