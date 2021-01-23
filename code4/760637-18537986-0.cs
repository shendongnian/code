    private void some_event(object sender, EventArgs e)
    {
        MainForm.SkipNextClipboardMessage = true;
        // some code that makes the clipboard changed message fire
    }
    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_CLIPBOARDUPDATE: 
                if (SkipNextClipboardMessage)
                    SkipNextClipboardMessage = false;
                else                    
                    OnClipboardChanged();
                break;
        }
        base.WndProc(ref m);
    }
