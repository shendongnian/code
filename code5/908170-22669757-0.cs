    protected void btnSubmitJournalEntry_Click(object sender, EventArgs e)
    {
        if (SearchGrid.SelectedRow == null)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please search and select user')", true);
        }
        else
        {
            ....
        }
    }
