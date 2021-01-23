    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication11
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SuspendDrawing(this);
            }
    
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, Int32 wMsg,
                                                 bool wParam, Int32 lParam);
    
            private const int WM_SETREDRAW = 11;
            private const int WM_PAINT = 0xf;
            private const int WM_CREATE = 0x1;
    
            public static void SuspendDrawing(Form parent)
            {
                SendMessage(parent.Handle, WM_PAINT, false, 0);
            }
    
            public static void ResumeDrawing(Form parent)
            {
                SendMessage(parent.Handle, WM_PAINT, true, 0);
             //   parent.Refresh();
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                SuspendDrawing((this));
            }
    
        }
    }
