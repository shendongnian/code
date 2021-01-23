    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.AddMessageFilter(new ButtonLogger());
        }
    }
    public class ButtonLogger : IMessageFilter
    {
        private const int WM_KEYUP = 0x101;
        private const int WM_LBUTTONUP = 0x202;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_LBUTTONUP || (m.Msg == WM_KEYUP && ((int)m.WParam == 32 || (int)m.WParam == 13)))
            {
                Control ctl = Control.FromHandle(m.HWnd);
                if (ctl is Button)
                {
                    LogButtonClick((Button)ctl);
                }
            }
            return false; // allow normal processing of all messages
        }
        private void LogButtonClick(Button btn)
        {
            WriteLog("Click: " + btn.Parent.Name.ToString() + "." + btn.Name.ToString() + " (\"" + btn.Text + "\")");
        }
        private void WriteLog(string message)
        {
            Console.WriteLine(message);
        }
    }
