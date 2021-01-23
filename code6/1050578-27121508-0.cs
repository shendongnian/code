    private void Exit_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult = MessageBox.Show("Text here", "Header here", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
            Close();
        }
    }
