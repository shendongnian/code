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
    
                    if (m.Msg == 0x100) // WM_KEYDOWN
                    {
                       // check if it was enter - I don't know how
                       if(enterWasPressed) 
                       {
                          PressedEnter();
                          return true;
                       }
                    }
    
                    return false;
                }
            }
