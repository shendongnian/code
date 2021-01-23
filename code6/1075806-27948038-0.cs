    public partial class Form1 : Form
    {
        private SyncListBoxes _SyncListBoxes = null;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this._SyncListBoxes = new SyncListBoxes(this.syncListView1, this.syncListView2);
        }
    }
    public class SyncListBoxes
    {
        private ListBox _LB1 = null;
        private ListBox _LB2 = null;
        private ListBoxScroll _ListBoxScroll1 = null;
        private ListBoxScroll _ListBoxScroll2 = null;
        public SyncListBoxes(ListBox LB1, ListBox LB2)
        {
            if (LB1 != null && LB1.IsHandleCreated && LB2 != null && LB2.IsHandleCreated && 
                LB1.Items.Count == LB2.Items.Count && LB1.Height == LB2.Height)
            {
                this._LB1 = LB1;
                this._ListBoxScroll1 = new ListBoxScroll(LB1);
                this._ListBoxScroll1.Scroll += _ListBoxScroll1_VerticalScroll;
                this._LB2 = LB2;
                this._ListBoxScroll2 = new ListBoxScroll(LB2);
                this._ListBoxScroll2.Scroll += _ListBoxScroll2_VerticalScroll;
                this._LB1.SelectedIndexChanged += _LB1_SelectedIndexChanged;
                this._LB2.SelectedIndexChanged += _LB2_SelectedIndexChanged;
            }
        }
        private void _LB1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._LB2.TopIndex != this._LB1.TopIndex)
            {
                this._LB2.TopIndex = this._LB1.TopIndex;
            }
            if (this._LB2.SelectedIndex != this._LB1.SelectedIndex)
            {
                this._LB2.SelectedIndex = this._LB1.SelectedIndex;
            }
        }
        private void _LB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._LB1.TopIndex != this._LB2.TopIndex)
            {
                this._LB1.TopIndex = this._LB2.TopIndex;
            }
            if (this._LB1.SelectedIndex != this._LB2.SelectedIndex)
            {
                this._LB1.SelectedIndex = this._LB2.SelectedIndex;
            }
        }
        private void _ListBoxScroll1_VerticalScroll(ListBox LB)
        {
            if (this._LB2.TopIndex != this._LB1.TopIndex)
            {
                this._LB2.TopIndex = this._LB1.TopIndex;
            }
        }
        private void _ListBoxScroll2_VerticalScroll(ListBox LB)
        {
            if (this._LB1.TopIndex != this._LB2.TopIndex)
            {
                this._LB1.TopIndex = this._LB2.TopIndex;
            }
        }
        private class ListBoxScroll : NativeWindow
        {
            private ListBox _LB = null;
            private const int WM_VSCROLL = 0x115;
            private const int WM_MOUSEWHEEL = 0x20a;
            public event dlgListBoxScroll Scroll;
            public delegate void dlgListBoxScroll(ListBox LB);
            
            public ListBoxScroll(ListBox LB)
            {
                this._LB = LB;
                this.AssignHandle(LB.Handle);
            }
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                switch (m.Msg)
                {
                    case WM_VSCROLL:
                    case WM_MOUSEWHEEL:                        
                        if (this.Scroll != null)
                        {
                            this.Scroll(_LB);
                        }
                        break;
                }
            }
        }
    }
