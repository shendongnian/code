        RadPanel panel = new RadPanel();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeComponent();
            panel.Dock = DockStyle.Fill;
            panel.BackColor = Color.Red;
            panel.Parent = this;
            RadButton b = new RadButton();
            b.Text = "button1";
            panel.Controls.Add(b);
            RadButton b2 = new RadButton();
            b2.Text = "button1";
            b2.Location = new Point(400, 400);
            panel.Controls.Add(b2);
        
        }
        private class PanelPrinter : IPrintable
        {
            private RadPanel panel;
            public PanelPrinter(RadPanel panel)
            {
                this.panel = panel;
            }
            public int BeginPrint(RadPrintDocument sender, PrintEventArgs args)
            {
                return 1;
            }
            public bool EndPrint(RadPrintDocument sender, PrintEventArgs args)
            {
                return false;
            }
            public Form GetSettingsDialog(RadPrintDocument document)
            {
                return null;
            }
            public bool PrintPage(int pageNumber, RadPrintDocument sender, PrintPageEventArgs args)
            {
                float scale = Math.Min((float)args.MarginBounds.Width / panel.Size.Width, (float)args.MarginBounds.Height / panel.Size.Height);
                
                Bitmap panelBmp = new Bitmap(this.panel.Width, this.panel.Height);
                this.panel.DrawToBitmap(panelBmp, this.panel.Bounds);
                Matrix saveMatrix = args.Graphics.Transform;
                args.Graphics.ScaleTransform(scale, scale);
                args.Graphics.DrawImage(panelBmp, args.MarginBounds.Location);
                args.Graphics.Transform = saveMatrix;
                 
                return false;
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            RadPrintDocument document = new RadPrintDocument();
            document.AssociatedObject = new PanelPrinter(this.panel);
            RadPrintPreviewDialog dialog = new RadPrintPreviewDialog(document);
            dialog.ShowDialog();
        }
