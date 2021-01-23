    protected void yourGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowState == DataControlRowState.Edit)
        {
            TextBox yourTextBox = (TextBox)e.Row.FindControl("yourTextBoxID");
            // At this point, you can change the value as normal
            yourTextBox.Text = "some new text";
        }
    }
