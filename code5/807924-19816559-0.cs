    public class MyListView : ListView
    {
        private const int WM_MOUSEWHEEL = 0x20a;
        public event EventHandler<EventArgs> Scrolled;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_MOUSEWHEEL && Scrolled != null)
            {
                Scrolled(this, new EventArgs());
            }
        }
    }
