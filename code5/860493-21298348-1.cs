    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        numOfRows = ds.Tables[0].Rows.Count;//so we know when to get redirected to results page
        
        //if we are at over max questions then go right to results page
        if (myNum >= numOfRows)
        {
            Response.Redirect("~/QuizResult.aspx");
        }
        Question.InnerText = ds.Tables[0].Rows[myNum]["Question"].ToString();//very first question
    }
