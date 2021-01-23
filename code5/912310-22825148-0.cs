    class MyComboBox : ComboBox, IMessageFilter
    {
            private ToolStripDropDown m_dropDown;
            MyComboBox()
            {
                ...
                Application.AddMessageFilter(this);
                ...
            }
            protected override void Dispose(bool disposing)
            {
                ...
                Application.RemoveMessageFilter(this);
                base.Dispose(disposing);
            }
            private const int WM_LBUTTONDOWN = 0x0201;
            private const int WM_RBUTTONDOWN = 0x0204;
            private const int WM_MBUTTONDOWN = 0x0207;
            private const int WM_NCLBUTTONDOWN = 0x00A1;
            private const int WM_NCRBUTTONDOWN = 0x00A4;
            private const int WM_NCMBUTTONDOWN = 0x00A7;
            [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
            [ResourceExposure(ResourceScope.None)]
            public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In, Out] ref Point pt, int cPoints);
            public bool PreFilterMessage(ref Message m)
            {
                if (m_dropDown.Visible)
                {
                    switch (m.Msg)
                    {
                        case WM_LBUTTONDOWN:
                        case WM_RBUTTONDOWN:
                        case WM_MBUTTONDOWN:
                        case WM_NCLBUTTONDOWN:
                        case WM_NCRBUTTONDOWN:
                        case WM_NCMBUTTONDOWN:
                            //
                            // When a mouse button is pressed, we should determine if it is within the client coordinates
                            // of the active dropdown.  If not, we should dismiss it.
                            //
                            int i = unchecked((int)(long)m.LParam);
                            short x = (short)(i & 0xFFFF);
                            short y = (short)((i >> 16) & 0xffff);
                            Point pt = new Point(x, y);
                            MapWindowPoints(m.HWnd, m_dropDown.Handle, ref pt, 1);
                            if (!m_dropDown.ClientRectangle.Contains(pt))
                            {
                                // the user has clicked outside the dropdown
                                pt = new Point(x, y);
                                MapWindowPoints(m.HWnd, Handle, ref pt, 1);
                                if (!ClientRectangle.Contains(pt))
                                {
                                    // the user has clicked outside the combo
                                    hideDropDown();
                                }
                            }
                            break;
                    }
                }
                return false;
            }
    }
