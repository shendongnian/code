    void MdiClient_Scroll(object sender, ScrollEventArgs e) {
        if (e.Type == ScrollEventType.EndScroll) {
            // Do your stuff
            //...
        }
    }
    private MdiClientWrapper wrapper;
    protected override void OnHandleCreated(EventArgs e) {
        // Find the MdiClient and sub-class it so we can get the Scroll event
        base.OnHandleCreated(e);
        if (wrapper != null) wrapper.Scroll -= MdiClient_Scroll;
        var client = this.Controls.OfType<MdiClient>().First();
        wrapper = new MdiClientWrapper();
        wrapper.AssignHandle(client.Handle);
        wrapper.Scroll += MdiClient_Scroll;
    }
    private class MdiClientWrapper : NativeWindow {
        public event ScrollEventHandler Scroll;
        private int oldPos;
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x115) {   // Trap WM_VSCROLL
                var type = (ScrollEventType)(m.WParam.ToInt32() & 0xffff);
                var pos = m.WParam.ToInt32() >> 16;
                Scroll(this, new ScrollEventArgs(type, oldPos, pos));
                oldPos = pos;
            }
            base.WndProc(ref m);
        }
    }
