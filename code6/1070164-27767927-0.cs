    using System.Windows.Forms;
    using MouseKeyboardActivityMonitor.WinApi;
    namespace Demo
    {
        public partial class MainForm : Form
        {
            private readonly KeyboardHookListener hook=new KeyboardHookListener(new GlobalHooker());
            public MainForm()
            {
                InitializeComponent();
                hook.KeyDown += hook_KeyDown;
                hook.Enabled = true;
            }
            void hook_KeyDown(object sender, KeyEventArgs e)
            {
                if(e.Control && e.Alt && e.KeyCode==Keys.F12)
                    MessageBox.Show(@"Alt+Ctrl+F12 Pressed.");
            }
        }
    }
