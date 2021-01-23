    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == 0x0020) //WM_SETCURSOR
        {
            //wParam is the window handle where the cursor is over
            if ( m.WParam == splitContainer1.Panel1.Handle || m.WParam == splitContainer1.Panel2.Handle )
            {
                if ( ((int)m.LParam & 0xFFFF) == 18 ) //low 16bits of lParam -> HTBORDER
                    if ( (((int)m.LParam & 0xFFFF0000) >> 16) == 0x0201) //hight 16bits -> WM_LBUTTONDOWN 
                    {
                        //mouse is down
                    }
                }
            }
        }
    }
