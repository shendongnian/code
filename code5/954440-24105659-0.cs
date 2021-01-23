    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.ClosingReason == CloseReason.UserClosing && MessageBox.Show("Exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
