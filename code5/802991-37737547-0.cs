     public class ToolTipComboBox: ComboBox
    {
        #region Fields
        private ToolTip toolTip;
        private bool _tooltipVisible;
        #endregion
        #region Types
        [StructLayout(LayoutKind.Sequential)]
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
            STATE_SYSTEM_NONE = 0,
            STATE_SYSTEM_INVISIBLE = 0x00008000,
            STATE_SYSTEM_PRESSED = 0x00000008
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
        } 
        #endregion
        #region Methods
        private void OnDrawItem(object sender, DrawItemEventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (e.Index == -1) return;
            string text = cbo.GetItemText(cbo.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            {
                TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds.Location, cbo.ForeColor);
            }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                Size szText = TextRenderer.MeasureText(text, cbo.Font);
                if (szText.Width > cbo.Width - SystemInformation.VerticalScrollBarWidth && !_tooltipVisible)
                {
                    RECT dropDownListRectangle;
                    GetWindowRect(HwndDropDown, out dropDownListRectangle);
                    RECT comboBoxRectangle;
                    GetWindowRect(HwndCombo, out comboBoxRectangle);
                    if (comboBoxRectangle.Top > dropDownListRectangle.Top)
                    {
                        // Top DropDown Window
                        toolTip.Show(text, cbo, e.Bounds.X, e.Bounds.Y - dropDownListRectangle.Rect.Height - cbo.ItemHeight - 5);
                    }
                    else
                    {
                        // Bottom DropDown Window  
                        toolTip.Show(text, cbo, e.Bounds.X, e.Bounds.Y + cbo.ItemHeight - cbo.ItemHeight);
                    }
                    _tooltipVisible = true;
                }
            }
            else
            {
                if (_tooltipVisible)
                {
                    toolTip.Hide(cbo);
                    _tooltipVisible = false;
                }
            }
            e.DrawFocusRectangle();
        }
        private void OnDropDownClosed(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (_tooltipVisible)
            {
                toolTip.Hide(cbo);
                _tooltipVisible = false;
            }
        } 
        #endregion
    }
