    private void Exit_Click(object sender, EventArgs e)
    {
        if (_rotrButtonClicked &&
            MessageBox("Would you like to save this file?",
                "Media Player",
                MessageBoxButtons.YesNo).Show() == DialogResult.Yes)
        {
            // save the changes
        }
    }
