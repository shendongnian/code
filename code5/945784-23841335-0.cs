            private void zedGraphControl_MouseLeave(object sender, EventArgs e)
            {
                if(this.Location == new Point(12, 400))
                    this.Location = new Point(Width / 2 - this.Width / 2, Height / 2 - this.Height / 2);
            }
    
            private void zedGraphControl_MouseEnter(object sender, EventArgs e)
            {
                if (this.Location == new Point(Width / 2 - this.Width / 2, Height / 2 - this.Height / 2))
                    this.Location = new Point(12, 400);
            }
    
            protected override void OnMouseLeave(EventArgs e)
            {
                this.Refresh();
                this.Invalidate();
                base.OnMouseLeave(e);
            }
    
            protected override void OnMouseEnter(EventArgs e)
            {
                this.Refresh();
                this.Invalidate();
                base.OnMouseEnter(e);
            }
