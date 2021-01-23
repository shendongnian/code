    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    /* A color bordered combobox 
     */
    namespace yo3hcv
    {
        public partial class BorderedComboBox : ComboBox
        {
    
            public BorderedComboBox()
                : base()
            {
    
                SetStyle(ControlStyles.DoubleBuffer, true);
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                SetStyle(ControlStyles.UserPaint, false);
    
    
            }
    
            private const int WM_SIZE = 0x0005;
            private const int WM_SIZING = 0x0214;
            private const int WM_ERASEBKGND = 0x14;
            private const int WM_PAINT = 0xF;
            private const int WM_NC_PAINT = 0x85;
            private const int WM_PRINTCLIENT = 0x318;
            private const int WM_MOUSEHOVER = 0x2A1;
            private const int WM_MOUSELEAVE = 0x2A3;
    
    
    
            private Color _BorderColor = SystemColors.Window;
            //private Color _BorderColor = Color.Red;
    
            [Category("BorderFocusStyle")]
            [Description("User-defined border color.")]
            public Color BorderColor
            {
                get
                {
                    return _BorderColor;
                }
                set
                {
                    _BorderColor = value;
                    Invalidate();
                }
            }
    
    
            protected override void OnGotFocus(System.EventArgs e)
            {
                Invalidate();
                base.OnGotFocus(e);
            }
    
            protected override void OnLostFocus(System.EventArgs e)
            {
                Invalidate();
                base.OnLostFocus(e);
            }
    
            protected override void OnResize(EventArgs e)
            {
                Invalidate();
                base.OnResize(e);
            }
    
            protected override void OnSelectedValueChanged(EventArgs e)
            {
                Invalidate();
                base.OnSelectedValueChanged(e);
            }
    
            protected override void WndProc(ref Message m)
            {
                IntPtr hDC;
                Graphics gdc;
    
                if (this.DropDownStyle == ComboBoxStyle.Simple)
                {
                    base.WndProc(ref m);
                    return;
                }
    
                switch (m.Msg)
                {
                    case WM_NC_PAINT:
                        break;
    
                    case WM_PAINT:
                        base.WndProc(ref m);
    
                        hDC = GetDC(this.Handle);
                        gdc = Graphics.FromHdc(hDC);
    
    
                        Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
    
                        ControlPaint.DrawBorder(gdc, rect, _BorderColor, ButtonBorderStyle.Solid);
    
                        ReleaseDC(m.HWnd, hDC);
    
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
    
    
            [DllImport("user32.dll")]
            static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);
    
            [DllImport("user32")]
            private static extern IntPtr GetDC(IntPtr hWnd);
    
    
        }
    }
 
