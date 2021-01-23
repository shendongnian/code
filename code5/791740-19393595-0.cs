        public Form1() {
            InitializeComponent();
            toolStrip1.Renderer = new MyRenderer();
        }
        private class MyRenderer : ToolStripProfessionalRenderer {
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
                if (e.Item is ToolStripItem) e.Text = e.Text.Replace("&", "&&");
                base.OnRenderItemText(e);
            }
        }
