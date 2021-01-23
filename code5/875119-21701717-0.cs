        private readonly ToolStripDropDown _toolStripDropDown = new ToolStripDropDown
        {
            //TopLevel = false,
            CanOverflow = true,
            AutoClose = true,
            DropShadowEnabled = true
        };
        public Form4()
        {
            InitializeComponent();
            var label = new Label { Text = "Ups" };
            var host = new ToolStripControlHost(label)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = label.Size
            };
            _toolStripDropDown.Size = label.Size;
            _toolStripDropDown.Items.Add(host);
            //Controls.Add(_toolStripDropDown);
        }
        private void button1_Click(Object sender, EventArgs e)
        {
            Point pt = this.PointToScreen(button1.Location);
            pt.Offset(0, button1.Height);
            _toolStripDropDown.Show(pt);
        }
