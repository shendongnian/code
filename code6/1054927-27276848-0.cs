    private bool isClicked = false, secondTime = false;
    private void FilteringToolStripMenuItem_Click(object sender, EventArgs e)
    {    
        isClicked = true;
        string link = "http:...";
        MessageBox.Show("explanation...", "Filtering", MessageBoxButtons.OK,
        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, link);
        isClicked = true; 
    }
    private void ShowMsgBox()
    {
        secondTime = true;
        string link = "http:...";
        MessageBox.Show("explanation...", "Filtering", MessageBoxButtons.OK,
        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, link);
        secondTime = false;
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x53) //WM_HELP message
        {
            if (isClicked == false)
            {
                if (secondTime == false)
                {
                    ShowMsgBox();
                }
            }
        }
        base.WndProc(ref m);
    }
