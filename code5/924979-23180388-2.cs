     protected void grdCustomPagging_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "TakeQuiz")
        {
            LinkButton lnkView = (LinkButton)e.CommandSource;
            string lectureId= lnkView.CommandArgument;
          // write link button click event code here
        }
    }
