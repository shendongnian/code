    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      panel1.AutoScroll = false;
      panel1.AutoScrollMinSize = new Size(1000, 0);
      panel1.AutoScrollPosition = new Point((panel1.AutoScrollMinSize.Width -
                                             panel1.ClientSize.Width) / 2, 0);
    }
