    public partial class Form1 : Form, IMessageFilter
    {
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        Keys lastKeyPressed = Keys.None;
        public Form1()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            this.FormClosed += (s, e) => Application.RemoveMessageFilter(this);
        }
        public bool PreFilterMessage(ref Message m) 
        {
            if(m.Msg == WM_KEYUP)
            {
                Debug.WriteLine("Filter -> KeyUp LastKeyPressed=" + lastKeyPressed.ToString());
            }
            return false;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                lastKeyPressed = keyData;
                switch (keyData)
                {
                    case Keys.Down:
                        Debug.WriteLine("Down Arrow Captured");
                        break;
                    case Keys.Up:
                        Debug.WriteLine("Up Arrow Captured");
                        break;
                    case Keys.Tab:
                        Debug.WriteLine("Tab Key Captured");
                        break;
                    case Keys.Control | Keys.M:
                        Debug.WriteLine("<CTRL> + M Captured");
                        break;
                    case Keys.Alt | Keys.Z:
                        Debug.WriteLine("<ALT> + Z Captured");
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
				
