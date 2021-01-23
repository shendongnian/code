    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      this.AutoScroll = false;
      this.AutoScrollMinSize = new Size(panel1.Width, 0);
      this.AutoScrollPosition = new Point((this.AutoScrollMinSize.Width -
                                           this.ClientSize.Width) / 2, 0);
    }
