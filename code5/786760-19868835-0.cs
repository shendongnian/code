    public partial class Form16 : Form,IMessageFilter
    {
        public Form16()
        {
            InitializeComponent();
        }
 
        private void Form16_Load(object sender, EventArgs e)
        {
            this.axWindowsMediaPlayer1.URL = @"D:\MyVideo\myfile.wmv";
            Application.AddMessageFilter(this);
        }
 
        private void Form16_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.RemoveMessageFilter(this);
        }
 
        #region IMessageFilter Members
        private const UInt32 WM_KEYDOWN = 0x0100;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)(int)m.WParam & Keys.KeyCode;
                if (keyCode == Keys.Escape)
                {
                    this.axWindowsMediaPlayer1.fullScreen = false;
                }
                return true;
            }
            return false;
        }
        #endregion
    }
