    private void DisablePreceedingCheckboxes()
    {
        checkBox2.Checked = false; 
        checkBox3.Checked = false;
        // ...
    }
    private void SetLineTextboxesEnabled(bool enabled)
    {
        textBox1.Enabled = enabled;
        textBox2.Enabled = enabled;
    }
    private bool UserConfirmedWarning(string message)
    {
        return MessageBox.Show(message, "Warning",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
    }
