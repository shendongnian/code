    protected void chkBox_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = sender as CheckBox ;
        if(chk.Checked)
        {
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            IDTextBox.Text = row.Cells[1].Text;
            loadnumTextBox.Text = row.Cells[2].Text;
        }
    }
