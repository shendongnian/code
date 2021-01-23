    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    
            [DllImport("user32.dll")]
            static extern IntPtr FindWindow(IntPtr classname, string title);
    
            [DllImport("user32.dll")]
            static extern void MoveWindow(IntPtr hwnd, int X, int Y,int nWidth, int nHeight, bool rePaint);
                
            [DllImport("user32.dll")]
            static extern bool GetWindowRect(IntPtr hwnd, out Rectangle rect);
                
    
            public Form1()
            {
                InitializeComponent();
                FindAndMoveMsgBox(0, 0, true, "Title");
                MessageBox.Show("Message", "Title");
            }
    
            void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
            {
                Thread thr = new Thread(() => // create a new thread
                {
                    IntPtr msgBox = IntPtr.Zero;
                    // while there's no MessageBox, FindWindow returns IntPtr.Zero
                    while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                    // after the while loop, msgBox is the handle of your MessageBox
                    Rectangle r = new Rectangle();
                    GetWindowRect(msgBox, out r); // Gets the rectangle of the message box
                    MoveWindow(msgBox /* handle of the message box */, x, y,
                       r.Width - r.X /* width of originally message box */,
                       r.Height - r.Y /* height of originally message box */,
                       repaint /* if true, the message box repaints */);
                });
                thr.Start(); // starts the thread
            }
        }
    }
