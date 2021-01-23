    public partial class Form1 : Form
    {
        private Label waterMarkLabel;
        public Form1()
        {
            waterMarkLabel = new Label
            {
                Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right),
                Font = new Font("Microsoft Sans Serif", 80F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = SystemColors.ControlDarkDark,
                Location = new Point(126, 178),
                Name = "WATERMARK",
                Size = new Size(338, 120),
                TabIndex = 0,
                Text = "W A T E R M A R K",
                TextAlign = ContentAlignment.MiddleCenter
            };
            InitializeComponent();
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 489);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Opacity = 0.1D;
            ShowIcon = false;
            ShowInTaskbar = false;
            TopMost = true;
            var hwnd = Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
            TopMost = true;
            AllowTransparency = true;
            ResumeLayout(false);
            Controls.Add(waterMarkLabel);
            WindowState = FormWindowState.Maximized;
        }
    }
    public static class WindowsServices
    {
        const int WS_EX_TRANSPARENT = 0x00000020;
        const int GWL_EXSTYLE = (-20);
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);
        public static void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
    }
