    Control draggingControl = new Control { BackColor = Color.Green, Visible = false };
    public MockForm() {
      InitializeComponent();
      this.Controls.Add(draggingControl);
      splitter1.SplitterMoving += splitter1_SplitterMoving;
      splitter1.SplitterMoved += splitter1_SplitterMoved;
    }
    void splitter1_SplitterMoving(object sender, SplitterEventArgs e) {
      draggingControl.Bounds = new Rectangle(new Point(e.X - (e.X - e.SplitX), 0),
                                             splitter1.Size);
      if (!draggingControl.Visible) {
        draggingControl.Visible = true;
        draggingControl.BringToFront();
      }
      this.Refresh();
    }
    void splitter1_SplitterMoved(object sender, SplitterEventArgs e) {
      draggingControl.Visible = false;
      this.Refresh();
    }
