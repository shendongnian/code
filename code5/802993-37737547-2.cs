    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public RECT(Rectangle rect)
        {
            Left = rect.Left;
            Top = rect.Top;
            Right = rect.Right;
            Bottom = rect.Bottom;
        }
        public Rectangle Rect
        {
            get
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }
        public Point Location
        {
            get
            {
                return new Point(Left, Top);
            }
        }
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    public class ToolTipComboBox: ComboBox
    {
        #region Fields
        private ToolTip toolTip;
        private bool _tooltipVisible;
        private bool _dropDownOpen;
        #endregion
        #region Types
        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable once InconsistentNaming
        public struct COMBOBOXINFO
        {
            public Int32 cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public ComboBoxButtonState buttonState;
            public IntPtr hwndCombo;
            public IntPtr hwndEdit;
            public IntPtr hwndList;
        }
        public enum ComboBoxButtonState
        {
            // ReSharper disable once UnusedMember.Global
            StateSystemNone = 0,
            // ReSharper disable once UnusedMember.Global
            StateSystemInvisible = 0x00008000,
            // ReSharper disable once UnusedMember.Global
            StateSystemPressed = 0x00000008
        }
        [DllImport("user32.dll")]
        public static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO pcbi);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        #endregion
        #region Properties
        private IntPtr HwndCombo
        {
            get
            {
                COMBOBOXINFO pcbi = new COMBOBOXINFO();
                pcbi.cbSize = Marshal.SizeOf(pcbi);
                GetComboBoxInfo(Handle, ref pcbi);
                return pcbi.hwndCombo;
            }
        }
        private IntPtr HwndDropDown
        {
            get
            {
                COMBOBOXINFO pcbi = new COMBOBOXINFO();
                pcbi.cbSize = Marshal.SizeOf(pcbi);
                GetComboBoxInfo(Handle, ref pcbi);
                return pcbi.hwndList;
            }
        }
        [Browsable(false)]
        public new DrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { base.DrawMode = value; }
        }
        #endregion
        #region ctor
        public ToolTipComboBox()
        {
            toolTip = new ToolTip
            {
                UseAnimation = false,
                UseFading = false
            };
            base.DrawMode = DrawMode.OwnerDrawFixed;
            DrawItem += OnDrawItem;
            DropDownClosed += OnDropDownClosed;
            DropDown += OnDropDown;
            MouseLeave += OnMouseLeave;
        }
        #endregion
        #region Methods
        private void OnDropDown(object sender, EventArgs e)
        {
            _dropDownOpen = true;
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            ResetToolTip();
        }
        private void ShowToolTip(string text, int x, int y)
        {
            toolTip.Show(text, this, x, y);
            _tooltipVisible = true;
        }
        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (e.Index == -1) return;
            // ReSharper disable once PossibleNullReferenceException
            string text = cbo.GetItemText(cbo.Items[e.Index]);
            e.DrawBackground();
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds.Location, SystemColors.Window);
                if (_dropDownOpen)
                {
                    Size szText = TextRenderer.MeasureText(text, cbo.Font);
                    if (szText.Width > cbo.Width - SystemInformation.VerticalScrollBarWidth && !_tooltipVisible)
                    {
                        RECT rcDropDown;
                        GetWindowRect(HwndDropDown, out rcDropDown);
                        RECT rcCombo;
                        GetWindowRect(HwndCombo, out rcCombo);
                        if (rcCombo.Top > rcDropDown.Top)
                        {
                            ShowToolTip(text, e.Bounds.X, e.Bounds.Y - rcDropDown.Rect.Height - cbo.ItemHeight - 5);
                        }
                        else
                        {
                            ShowToolTip(text, e.Bounds.X, e.Bounds.Y + cbo.ItemHeight - cbo.ItemHeight);
                        }
                    }
                }
            }
            else
            {
                ResetToolTip();
                TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds.Location, cbo.ForeColor);
            }
            e.DrawFocusRectangle();
        }
        private void OnDropDownClosed(object sender, EventArgs e)
        {
            _dropDownOpen = false;
            ResetToolTip();
        }
        private void ResetToolTip()
        {
            if (_tooltipVisible)
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                toolTip.SetToolTip(this, null);
                _tooltipVisible = false;
            }
        }
        #endregion
    }
