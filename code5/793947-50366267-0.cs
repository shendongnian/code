    using System; 
    using System.Drawing; 
    using System.Windows.Forms; 
    using System.Runtime.InteropServices; 
    
    namespace Demo_mousehook_csdn
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            MouseHook mh;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                mh = new MouseHook();
                mh.SetHook();
                mh.MouseMoveEvent += mh_MouseMoveEvent;
                mh.MouseClickEvent += mh_MouseClickEvent;
                mh.MouseDownEvent += mh_MouseDownEvent;
                mh.MouseUpEvent += mh_MouseUpEvent;
            }
            private void mh_MouseDownEvent(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    richTextBox1.AppendText("Left Button Press\n");
                }
                if (e.Button == MouseButtons.Right)
                {
                    richTextBox1.AppendText("Right Button Press\n");
                }
            }
            
            private void mh_MouseUpEvent(object sender, MouseEventArgs e)
            {
                 
                if (e.Button == MouseButtons.Left)
                {
                    richTextBox1.AppendText("Left Button Release\n");
                }
                if (e.Button == MouseButtons.Right)
                {
                    richTextBox1.AppendText("Right Button Release\n");
                }
        
            }
            private void mh_MouseClickEvent(object sender, MouseEventArgs e)
            {
                //MessageBox.Show(e.X + "-" + e.Y);
                if (e.Button == MouseButtons.Left)
                {
                    string sText = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
                    label1.Text = sText;
                }
            }
    
            private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                textBox1.Text = x + "";
                textBox2.Text = y + "";
            }
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                mh.UnHook();
            }
    
            private void Form1_FormClosed_1(object sender, FormClosedEventArgs e)
            {
                mh.UnHook();
            }
    
            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
    
            }
        }
    
        public class Win32Api
        {
            [StructLayout(LayoutKind.Sequential)]
            public class POINT
            {
                public int x;
                public int y;
            }
            [StructLayout(LayoutKind.Sequential)]
            public class MouseHookStruct
            {
                public POINT pt;
                public int hwnd;
                public int wHitTestCode;
                public int dwExtraInfo;
            }
            public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        }
    
        public class MouseHook
        {
            private Point point;
            private Point Point
            {
                get { return point; }
                set
                {
                    if (point != value)
                    {
                        point = value;
                        if (MouseMoveEvent != null)
                        {
                            var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
                            MouseMoveEvent(this, e);
                        }
                    }
                }
            }
            private int hHook;
            private const int WM_MOUSEMOVE = 0x200;
            private const int WM_LBUTTONDOWN = 0x201;
            private const int WM_RBUTTONDOWN = 0x204;
            private const int WM_MBUTTONDOWN = 0x207;
            private const int WM_LBUTTONUP = 0x202;
            private const int WM_RBUTTONUP = 0x205;
            private const int WM_MBUTTONUP = 0x208;
            private const int WM_LBUTTONDBLCLK = 0x203;
            private const int WM_RBUTTONDBLCLK = 0x206;
            private const int WM_MBUTTONDBLCLK = 0x209;
            public const int WH_MOUSE_LL = 14;
            public Win32Api.HookProc hProc;
            public MouseHook()
            {
                this.Point = new Point();
            }
            public int SetHook()
            {
                hProc = new Win32Api.HookProc(MouseHookProc);
                hHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
                return hHook;
            }
            public void UnHook()
            {
                Win32Api.UnhookWindowsHookEx(hHook);
            }
            private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                Win32Api.MouseHookStruct MyMouseHookStruct = (Win32Api.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseHookStruct));
                if (nCode < 0)
                {
                    return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
                }
                else
                {
                    if (MouseClickEvent != null)
                    {
                        MouseButtons button = MouseButtons.None;
                        int clickCount = 0;
                        switch ((Int32)wParam)
                        {
                            case WM_LBUTTONDOWN:
                                button = MouseButtons.Left;
                                clickCount = 1;
                                MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                            case WM_RBUTTONDOWN:
                                button = MouseButtons.Right;
                                clickCount = 1;
                                MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                            case WM_MBUTTONDOWN:
                                button = MouseButtons.Middle;
                                clickCount = 1;
                                MouseDownEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                            case WM_LBUTTONUP:
                                button = MouseButtons.Left;
                                clickCount = 1;
                                MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                            case WM_RBUTTONUP:
                                button = MouseButtons.Right;
                                clickCount = 1;
                                MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                            case WM_MBUTTONUP:
                                button = MouseButtons.Middle;
                                clickCount = 1;
                                MouseUpEvent(this, new MouseEventArgs(button, clickCount, point.X, point.Y, 0));
                                break;
                        }
    
                        var e = new MouseEventArgs(button, clickCount, point.X, point.Y, 0);
                        MouseClickEvent(this, e);
                    }
                    this.Point = new Point(MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y);
                    return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
                }
            }
    
            public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
            public event MouseMoveHandler MouseMoveEvent;
    
            public delegate void MouseClickHandler(object sender, MouseEventArgs e);
            public event MouseClickHandler MouseClickEvent;
    
            public delegate void MouseDownHandler(object sender, MouseEventArgs e);
            public event MouseDownHandler MouseDownEvent;
    
            public delegate void MouseUpHandler(object sender, MouseEventArgs e);
            public event MouseUpHandler MouseUpEvent;
    
        }
    }
