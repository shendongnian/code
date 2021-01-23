    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyTabControl : TabControl {
        public MyTabControl() {
            // Take over the painting completely, we want transparency and double-buffering
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.DoubleBuffered = this.ResizeRedraw = true;
        }
    
        public override Color BackColor {
            // Override TabControl.BackColor, we need transparency
            get { return Color.Transparent; }
            set { base.BackColor = Color.Transparent; }
        }
    
        protected virtual void DrawTabRectangle(Graphics g, int index, Rectangle r) {
            if (index == 0) r = new Rectangle(r.Left - 2, r.Top, r.Width + 2, r.Height);
            if (index != this.SelectedIndex) r = new Rectangle(r.Left, r.Top + 2, r.Width, r.Height - 2);
            Color tabColor;
            if (index == this.SelectedIndex) tabColor = Color.FromKnownColor(KnownColor.Window);
            else tabColor = Color.FromArgb(0xf0, 0xf0, 0xf0);
            using (var br = new SolidBrush(tabColor)) {
                g.FillRectangle(br, r);
            }
        }
    
        protected virtual void DrawTab(Graphics g, int index, Rectangle r) {
            r.Inflate(-1, -1);
            TextRenderer.DrawText(g, this.TabPages[index].Text, this.Font,
                r, Color.FromKnownColor(KnownColor.WindowText), 
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    
        protected override void OnPaint(PaintEventArgs e) {
            if (TabCount <= 0) return;
            // Draw tabpage area
            Rectangle r = ClientRectangle;
            var top = this.GetTabRect(0).Bottom;
            using (var br = new SolidBrush(Color.FromKnownColor(KnownColor.Window))) {
                e.Graphics.FillRectangle(br, new Rectangle(r.Left, top, r.Width, r.Height - top));
            }
            // Draw tabs
            for (int index = 0; index < TabCount; index++) {
                r = GetTabRect(index);
                DrawTabRectangle(e.Graphics, index, r);
                DrawTab(e.Graphics, index, r);
                if (index == this.SelectedIndex) {
                    r.Inflate(-1, -1);
                    ControlPaint.DrawFocusRectangle(e.Graphics, r);
                }
            }
        }
    }
