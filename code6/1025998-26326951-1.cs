    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
     
        if (m.Msg == WM_CLIPBOARDUPDATE)
        {
            IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data.
     
            if (iData.GetDataPresent(DataFormats.Text))
            {
                rtb1.Paste();
            }
         }
    }
