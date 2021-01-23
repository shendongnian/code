    private void rTB_test_DoubleClick(object sender, EventArgs e)
    {
        var ss = rTB_test.SelectionStart;
        var sl = rTB_test.SelectionLength;
        string id = GetID(sr);  //*4*
        // a few checks:
        if (sl == 1 &&  mailList.Keys.Contains(id) && sr.Contains(@"{\pict\") )
        {
           Microsoft.Office.Interop.Outlook.MailItem mi = mailList[id]; 
           // do stuff with the msgItem, e.g..
           mi.Display();
        }
    }
