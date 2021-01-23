    private bool hasChanges = false;
    
    private void RotRButton_Click(object sender, EventArgs e) {
        hasChanges = true;
    }
    private void Exit_Click(object sender, EventArgs e)
    {
        if (hasChanges)
        {
            if (MessageBox("Would you like to save this file?", "Media Player", MessageBoxButtons.YesNo) == DialogResult.Yes) {
               //Do something
            }
        }
    }
