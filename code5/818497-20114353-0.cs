    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason != CloseReason.UserClosing)
            return;    // Not closing - we don't care.
        if (MessageBox.Show("Are you Sure you want to Exit. Click Yes to Confirm and No to continue",
            "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
            e.Cancel = true;
            return;   // User didn't say Yes - don't exit.
        }
        if (timer2.Enabled == true)
        {
            // Only ask this question if timer2 is running.
            if (MessageBox.Show("Quit now will delete all the file of the current operation. Click Yes to Confirm and No to continue",
                "WinForm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                 e.Cancel = true;
                 return;    // User didn't say Yes - don't exit.
            }
         }
         // Quit
    }
