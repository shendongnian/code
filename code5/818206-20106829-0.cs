    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    public partial class Form1 : Form
    {
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        //private const int WM_xxx = 0x0;
        //you have to know for which event you wanna register
        public Form1()
        {
            InitializeComponent();
            IntPtr hWnd = this.Handle;
            Application.AddMessageFilter(new MyMessageFilter());
            PostMessage(hWnd, WM_xxx, IntPtr.Zero, IntPtr.Zero);
        }        
    }
    class MyMessageFilter : IMessageFilter
    {
        //private const int WM_xxx = 0x0;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_xxx)
            {
                //code to handle the message
            }
            return false;
        }
    }
