    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
                // Display a MsgBox asking the user to close the form.
                if (MessageBox.Show("Are you sure you want to close the form?", "Close Form",
                   MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                {
                    // Cancel the Closing event
                    e.Cancel = true;
                }
     
    }
