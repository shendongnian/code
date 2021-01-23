    public partial class MyForm : Form
    {
        //Window Messages
        public const uint WM_NCPAINT = 0x85;
        public const uint WM_NCCALCSIZE = 0x83;
        public const uint WM_NCHITTEST = 0x84;
        //GetDCEx Flags
        public const int DCX_WINDOW = 0x00000001;
        public const int DCX_CACHE = 0x00000002;
        public const int DCX_PARENTCLIP = 0x00000020;
        public const int DCX_CLIPSIBLINGS = 0x00000010;
        public const int DCX_CLIPCHILDREN = 0x00000008;
        public const int DCX_NORESETATTRS = 0x00000004;
        public const int DCX_LOCKWINDOWUPDATE = 0x00000400;
        public const int DCX_EXCLUDERGN = 0x00000040;
        public const int DCX_INTERSECTRGN = 0x00000080;
        public const int DCX_INTERSECTUPDATE = 0x00000200;
        public const int DCX_VALIDATE = 0x00200000;
        //RECT Structure
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }
        //WINDOWPOS Structure
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndinsertafter;
            public int x, y, cx, cy;
            public int flags;
        }
        //NCCALCSIZE_PARAMS Structure
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc0, rgrc1, rgrc2;
            public WINDOWPOS lppos;
        }
        //SetWindowTheme UXtheme Function
        [System.Runtime.InteropServices.DllImport("uxtheme.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        public static extern int SetWindowTheme(
            IntPtr hWnd,
            String pszSubAppName,
            String pszSubIdList);
        //GetWindowRect User32 Function
        [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool GetWindowRect(
            IntPtr hwnd,
            out  RECT lpRect
            );
        //GetWindowDC User32 Function
        [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetWindowDC(
            IntPtr hWnd
            );
        //GetDCEx User32 Function
        [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true)]
        public static extern IntPtr GetDCEx(
            IntPtr hWnd,
            IntPtr hrgnClip,
            int flags
            );
        //Window Procedure Hook
        protected override void WndProc(ref Message m)
        {
            //Don't style window in designer...
            if (DesignMode)
                base.WndProc(ref m);
            //Handle Message
            switch ((uint)m.Msg)
            {
                case WM_NCCALCSIZE: WmNCCalcSize(ref m); break;
                case WM_NCPAINT: WmNCPaint(ref m); break;
                default: base.WndProc(ref m); break;
            }
        }
        //Handle Creation
        protected override void OnHandleCreated(EventArgs e)
        {
            //Base Procedure...
            base.OnHandleCreated(e);
            //Remove Theme
            SetWindowTheme(this.Handle, string.Empty, string.Empty);
        }
        //WM_NCCALCSIZE
        private void WmNCCalcSize(ref Message m)
        {
            //Get Window Rect
            RECT formRect = new RECT();
            GetWindowRect(m.HWnd, out formRect);
            //Check WPARAM
            if (m.WParam != IntPtr.Zero)    //TRUE
            {
                //When TRUE, LPARAM Points to a NCCALCSIZE_PARAMS structure
                var nccsp = (NCCALCSIZE_PARAMS)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                //We're adjusting the size of the client area here. Right now, the client area is the whole form.
                //Adding to the Top, Bottom, Left, and Right will size the client area.
                nccsp.rgrc0.top += 30;      //30-pixel top border
                nccsp.rgrc0.bottom -= 4;    //4-pixel bottom (resize) border
                nccsp.rgrc0.left += 4;      //4-pixel left (resize) border
                nccsp.rgrc0.right -= 4;     //4-pixel right (resize) border
                //Set the structure back into memory
                System.Runtime.InteropServices.Marshal.StructureToPtr(nccsp, m.LParam, true);
            }
            else    //FALSE
            {
                //When FALSE, LPARAM Points to a RECT structure
                var clnRect = (RECT)System.Runtime.InteropServices.Marshal.PtrToStructure(m.LParam, typeof(RECT));
                //Like before, we're adjusting the rectangle...
                //Adding to the Top, Bottom, Left, and Right will size the client area.
                clnRect.top += 30;      //30-pixel top border
                clnRect.bottom -= 4;    //4-pixel bottom (resize) border
                clnRect.left += 4;      //4-pixel left (resize) border
                clnRect.right -= 4;     //4-pixel right (resize) border
                //Set the structure back into memory
                System.Runtime.InteropServices.Marshal.StructureToPtr(clnRect, m.LParam, true);
            }
            //Return Zero
            m.Result = IntPtr.Zero;
        }
        //WM_NCPAINT
        private void WmNCPaint(ref Message m)
        {
            //Store HDC
            IntPtr HDC = IntPtr.Zero;
            Graphics gfx = null;
            //Check the WPARAM
            if(m.WParam == (IntPtr)1)
            {
                //For reasons unknown to me, the update region doesn't contain valid data and calling GetDCEx will do nothing.
                //So I call GetWindowDC and exclude the area using System.Drawing.Graphics instead.
                //Graphics Object from HDC
                HDC = GetWindowDC(m.HWnd);
                gfx = Graphics.FromHdc(HDC);
                //Exclude Client Area
                gfx.ExcludeClip(new Rectangle(4, 30, Width - 8, 34));  //Exclude Client Area (GetWindowDC grabs the WHOLE window's graphics handle)
            }
            else
            {
                //Graphics Object from HDC
                HDC = GetDCEx(m.HWnd, m.WParam, DCX_WINDOW | DCX_INTERSECTRGN);
                gfx = Graphics.FromHdc(HDC);
            }
            //Call Paint
            using (PaintEventArgs ncPaintArgs = new PaintEventArgs(gfx, new Rectangle(0, 0, Width, Height)))
                MyForm_NCPaint(this, ncPaintArgs);
            //Return Zero
            m.Result = IntPtr.Zero;
        }
        public MyForm()
        {
            InitializeComponent();
        }
        private void MyForm_NCPaint(object sender, PaintEventArgs e)
        {
            //Clear
            e.Graphics.Clear(Color.Green);
        }
    }
