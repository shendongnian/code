    protected void QuestionLinkButton_Click(object sender, EventArgs e)
        {
            Session["LBQ"] = (sender as LinkButton).Text;
            Response.Redirect("Thread.aspx");
        }
