    private void mfsCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        checkForExtraStuff.Enabled = mfsCheckbox.Checked;
    }
    private void previewButton_Click(object sender, EventArgs e)
    {
        if (mfsCheckbox.Checked)
        {
            //do basic stuff
            if (checkForExtraStuff.Checked)
            {
                //do extra stuff
            }
        }
    }
