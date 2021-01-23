    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
    	base.WndProc(ref m);
    	if (m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
    	{
    		int scrollPos = 0;
    		if (m.Msg == WM_HSCROLL)
    		  scrollPos = GetScrollPos(this.Handle, SB_HORZ);
    		else
    		  scrollPos = GetScrollPos(this.Handle, SB_VERT);
    		
    		OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), scrollPos));
    	}
    }
