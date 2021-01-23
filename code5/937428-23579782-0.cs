    private void radioButton_CheckedChanged(object sender, EventArgs e)
    {
        id.Enabled = radio_ID.Checked;
        name.Enabled = radio_Name.Checked;
        salary.Enabled = radio_Salary.Checked;
        designation.Enabled = radio_Designation.Checked;
    }
