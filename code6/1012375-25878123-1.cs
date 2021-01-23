    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    //Let controls scroll without Focus();
    
    namespace YOURNAMESPACE
    {
        internal struct ScrollableControls : IMessageFilter
        {
            private const int WmMousewheel = 0x020A;
            private readonly Control[] _controls;
    
            public ScrollableControls(params Control[] controls)
            {
                _controls = controls;
            }
    
            bool IMessageFilter.PreFilterMessage(ref Message m)
            {
                if (m.Msg != WmMousewheel) return false;
                foreach (var item in _controls)
                {
                    ScrollControl(item, ref m);
                }
                return false;
            }
    
            [DllImport("user32.dll")]
            private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
    
            private static void ScrollControl(Control control, ref Message m)
            {
                if (control.RectangleToScreen(control.ClientRectangle).Contains(Cursor.Position) && control.Visible)
                {
                    SendMessage(control.Handle, m.Msg, m.WParam.ToInt32(), m.LParam.ToInt32());
                }
            }
        }
    }
