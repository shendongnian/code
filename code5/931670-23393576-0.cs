    bool ClosedFromMenu = false;
    private void sluitenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Het programma wordt hiermee gesloten.\nBent u zeker dat u wilt sluiten en uitloggen?",
            "Waarschuwing , u staat op het moment het programma te sluiten",MessageBoxButtons.YesNo, 
            MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
            ClosedFromMenu = true;
            Application.Exit();
        }
    }
    private void window_Closing(object sender, FormClosingEventArgs e)
    {
       if(!ClosedFromMenu)
       {
        if(MessageBox.Show("Bent u zeker dat u wilt uitloggen?","Waarschuwing , u staat op het moment uit te loggen",
             MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
        {
            loginForm.Show();
        }
        else
        {
            e.Cancel = true;
        }
       }
    }
