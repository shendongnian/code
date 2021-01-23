    private bool rtbKeyDown = false;
    private void Main_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Tab && e.Control)
        {
            try
            {
                if(rtbKeyDown == false)
                    Console.WriteLine("TAB+ Enter");
            }
            finally
            {
                rtbKeyDown = false;            
            }
        }
    }
    
    private void txtControl_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Enter)
        {
            rtbKeyDown = true;
            SendKeys.Send("{Tab}");
            // e.Handled = true; NOT NEEDED
            e.SuppressKeyPress = true;
        }
    }
