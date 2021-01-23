    public partial class Form1 : Form
    {
        [DllImport("user32")]
        private static extern int GetScrollPos(IntPtr hwnd, int nBar);
        public Form1()
        {
            InitializeComponent();
            chk.Text = ".NET pro";
            chk.Parent = richTextBox1;
            chk.Top = 100;//Notice the initial Top to update the position properly later.            
            nativeRichText.AssignHandle(richTextBox1.Handle);
            //Scroll event handler for the nativeRichText
            nativeRichText.Scroll += (s, e) =>
            {
                chk.Top = 100-e.Y;
            };
            //TextChanged event handler for the richTextBox1
            richTextBox1.TextChanged += (s, e) =>
            {
                chk.Top = 100-GetScrollPos(richTextBox1.Handle, 1);
            };            
        }
        CheckBox chk = new CheckBox();
        NativeRichTextBox nativeRichText = new NativeRichTextBox();        
        public class NativeRichTextBox : NativeWindow
        {
            Timer t = new Timer();
            int y = -1;
            public NativeRichTextBox()
            {
                t.Interval = 30;
                t.Tick += (s, e) =>
                {                                     
                    int y2 = Form1.GetScrollPos(Handle, 1);//nBar =1 => Vertical bar
                    if (y2 == y) { t.Stop(); return; }
                    y = y2;
                    if (Scroll != null) Scroll(this, new ScrollEventArgs(0, y));                    
                };
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x115)//WM_VSCROLL = 0x115
                {
                    int wp = m.WParam.ToInt32();
                    int low = wp & 0x00ff;
                    if (low == 4 || low == 5)//SB_THUMBPOSITION = 4   SB_THUMBTRACK = 5
                    {
                        if (Scroll != null) Scroll(this, new ScrollEventArgs(0, wp >> 16));
                    }
                    else t.Start();
                }
                if (m.Msg == 0x20a)//WM_MOUSEWHEEL = 0x20a
                {
                    y = -1;
                    t.Start();
                }
                base.WndProc(ref m);                
            }
            public class ScrollEventArgs : EventArgs
            {
                public int X { get; set; }
                public int Y { get; set; }
                public ScrollEventArgs(int x, int y)
                {
                    X = x;
                    Y = y;
                }
            }
            public delegate void ScrollEventHandler(object sender, ScrollEventArgs e);
            public event ScrollEventHandler Scroll;
        }
    }
