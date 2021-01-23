    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //using System.Runtime.InteropServices;
        // tell the runtime to use the user32.dll for implementation of the next method
        [DllImport("user32.dll")]
        // what is returned by this method
        [return: MarshalAs(UnmanagedType.Bool)]
        // the methed to call in User32
        // upper/lower case is important
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void Form1_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(this.Handle);
        }
    } 
