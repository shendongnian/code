    protected void txtData_TextChanged(object sender, EventArgs e)
    {
        if (!txtData.Text.Equals("") || !txtData.Text.toString().Equal(string.empty))
        {
            btnSearch.Enabled = true;
        }
    }
