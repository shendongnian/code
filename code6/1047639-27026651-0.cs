    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MapPanel : Panel {
        public MapPanel() {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    
        private Image map;
        public Image Map {
            get { return map; }
            set {
                map = value;
                this.AutoScrollMinSize = value == null ? Size.Empty : value.Size;
                this.Invalidate();
            }
        }
    
        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);
            if (map != null) {
                e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
                e.Graphics.DrawImage(map, 0, 0);
            }
        }
    }
