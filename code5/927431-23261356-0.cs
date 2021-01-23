    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            pnlSearch.Visible = false;
            pnlSearchResult.Visible = true;           
        }
    }
