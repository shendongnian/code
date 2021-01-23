    protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                this.mouseMessageFilter = new MouseMoveMessageFilter();
                this.mouseMessageFilter.TargetForm = this;
                Application.AddMessageFilter(this.mouseMessageFilter);
            }
    
    protected override void OnClosed(EventArgs e)
            {
                Application.RemoveMessageFilter(this.mouseMessageFilter);
    
                base.OnClosed(e);
            }
    
    private class MouseMoveMessageFilter : IMessageFilter
            {
                public FormMain TargetForm { get; set; }
                //Control ctrTmp;
    
                public bool PreFilterMessage(ref Message m)
                {
                    if (TargetForm.IsDisposed) return false;
    
                    int numMsg = m.Msg;
    
                    int VK_RETURN=0x0D;
                    if (m.Msg == 0x100 &&(int)m.WParam == VK_RETURN) // WM_KEYDOWN and enter pressed
                    {
                          if (TargetForm.PressedEnter()) return true;
                    }
    
                    return false;
                }
            }
