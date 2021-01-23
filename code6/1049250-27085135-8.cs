    private void rtf2_TextChanged(object sender, EventArgs e)
    {
        if (myEventHandler != null)
        {
         myEventHandler(this, new FirstWindowEventArgs(rtf2.Text.Substring(rtf2.Text.Length -1)));
        // rtf2.ForeColor = Color.FromName(e.ToString());
        }
    }
