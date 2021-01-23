       protected override void WndProc(ref Message m)
       {
            if (m.Msg == WM_CTLCOLORLISTBOX)
            {
                if(Control.FromHandle(m.HWnd) == this.objCombo)
                {
                    CaptureComboWndProc(ref m);
                }
            }
       }
    
       private void CaptureComboWndProc(ref Message m)
       {
           
       }
