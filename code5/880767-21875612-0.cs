    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Get the responses for the questions
        foreach (GridViewRow masterData in gvQuestions.Rows)
        {
            // the actual way to get your row index
            int rowIndex = masterData.RowIndex;
            //qID = (int)gvQuestions.DataKeys[(masterData.RowIndex)].Value;
            //response = ((DropDownList)masterData.FindControl("ddlResponse")).SelectedValue.ToString();
            DropDownList ddl = (DropDownList)gvQuestions.Rows[rowIndex ].FindControl("ddlResponse");
            responses = ddl.SelectedValue.ToString();
        }
    
    }
