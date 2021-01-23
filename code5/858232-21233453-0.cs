    class CustomHandleForm : Form
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            base.DestroyHandle();
        }
        protected override void DestroyHandle() { }        
    }
