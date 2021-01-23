    void tmr_Tick(object sender, EventArgs e)
    {
        tmr.Enabled = false;
        nValue++;
        MessageBox.Show(nValue.ToString());
        tmr.Enabled = true; 
    }
