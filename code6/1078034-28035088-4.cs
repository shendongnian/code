    private void rTB_test_DoubleClick(object sender, EventArgs e)
    {
        var ss = rTB_test.SelectionStart;
        var sl = rTB_test.SelectionLength;
        var sr = rTB_test.SelectedRtf;
        // a few checks:
        if (sl == 1 &&  mailList.Keys.Contains(ss) && sr.Contains(@"{\pict\") )
        {
           Microsoft.Office.Interop.Outlook.MailItem mi = mailList[ss]; 
           // do stuff with the msgItem..
           // ..
        }
    }
