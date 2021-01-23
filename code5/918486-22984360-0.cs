    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication_22979038
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
            private void MainForm_Load(object sender, EventArgs e)
            {
                this.webBrowser.DocumentText = "<a id='goLink' href='javascript:alert(\"Hello!\"),undefined'>Go</a><script></script>";
    
                this.webBrowser.DocumentCompleted += webBrowser_DocumentCompleted;
            }
    
            void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var element = this.webBrowser.Document.GetElementById("goLink");
                element.Focus();
                var hwnd = GetFocus();
                if (!IsChild(this.webBrowser.Handle, hwnd))
                    throw new ApplicationException("Unexpected focused window.");
    
                var rect = GetElementRect(element);
                IntPtr wParam = (IntPtr)MK_LBUTTON;
                IntPtr lParam = (IntPtr)(rect.Left | rect.Top << 16);
                PostMessage(hwnd, WM_LBUTTONDOWN, wParam, lParam);
                PostMessage(hwnd, WM_LBUTTONUP, wParam, lParam);
            }
    
            // get the element rect in window client area coordinates
            static Rectangle GetElementRect(HtmlElement element)
            {
                var rect = element.OffsetRectangle;
                int left = 0, top = 0;
                var parent = element;
                while (true)
                {
                    parent = parent.OffsetParent;
                    if (parent == null)
                        return new Rectangle(rect.X + left, rect.Y + top, rect.Width, rect.Height);
                    var parentRect = parent.OffsetRectangle;
                    left += parentRect.Left;
                    top += parentRect.Top;
                }
            }
    
            // interop
    
            const int MK_LBUTTON = 0x0001;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_LBUTTONUP = 0x0202;
    
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int x;
                public int y;
            }
    
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            static extern int PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
    
            [DllImport("User32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
            static extern IntPtr GetFocus();
    
            [DllImport("User32.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
            static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);
        }
    }
