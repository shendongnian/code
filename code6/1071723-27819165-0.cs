    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class DendrogramViewer : Panel {
        public DendrogramViewer() {
            this.DoubleBuffered = this.ResizeRedraw = true;
            this.BackColor = Color.FromKnownColor(KnownColor.Window);
        }
    
        public override System.Drawing.Font Font {
            get { return base.Font; }
            set { base.Font = value; setSize(); }
        }
    
        private int lines;
        public int Lines {
            get { return lines; }
            set { lines = value; setSize(); }
        }
    
        private void setSize() {
            var minheight = this.Font.Height * lines;
            this.AutoScrollMinSize = new Size(0, minheight);
        }
    
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            base.OnPaint(e);
        }
    }
