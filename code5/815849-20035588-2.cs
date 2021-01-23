    private void MainProg_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Add this line:
        if (e.CloseReason == CloseReason.ApplicationExitCall) return;
        // remainder of code as in original:
        DialogResult dialog = MessageBox.Show("Θέλετε πραγματικά να κλείσει η εφαρμογή?",
            "Κλείσιμο", MessageBoxButtons.YesNo);
        if (dialog == DialogResult.Yes )
        {
            Application.Exit();
        }
        else if (dialog == DialogResult.No)
        {
            e.Cancel = true;
        }
    }
