    private void rTB_test_DoubleClick(object sender, EventArgs e)
    {
        var ss = rTB_test.SelectionStart;
        var sl = rTB_test.SelectionLength;
        int hash = GetID(sr).GetHashCode();  //*3*
        // a few checks:
        if (sl == 1 &&  mailList.Keys.Contains(hash ) && sr.Contains(@"{\pict\") )
        {
           Microsoft.Office.Interop.Outlook.MailItem mi = mailList[hash ]; 
           // do stuff with the msgItem, e.g..
           mi.Display();
        }
    }
