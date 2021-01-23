    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {
            bool TRunning = false;
            IntPtr _f1Handle;
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
    
            private bool CheckIfForemost()
            {
                return GetForegroundWindow() == _f1Handle;
            }
            public Form2(IntPtr F1Handle)
            {
                TRunning = true;
                _f1Handle = F1Handle;
                InitializeComponent();
            }
            private void Form2_Load(object sender, EventArgs e)
            {
                new Thread(() =>
                {
                    while (TRunning)
                    {
                        Thread.Sleep(100);
                        if (CheckIfForemost())
                        {
                            this.TopMost = true;
                        }
                        this.TopMost = false;
                    }
                }).Start();
            }
        }
    }
