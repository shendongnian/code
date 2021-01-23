    private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.OKCancel);
        if (result == DialogResult.OK)
        {
            Environment.Exit(1);
        }
        else
        {
            e.Cancel = true;
        }
    }
