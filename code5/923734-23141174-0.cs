    private Timer timer = new Timer();
    public Form1() {
      InitializeComponent();
      timer.Tick += timer_Tick;
      timer.Start();
    }
    void timer_Tick(object sender, EventArgs e) {
      Rectangle r = pnlOne.RectangleToScreen(pnlOne.ClientRectangle);
      if (r.Contains(MousePosition)) {
        if (!pnlOne.Visible)
          pnlOne.Visible = true;
      } else {
        if (pnlOne.Visible)
          pnlOne.Visible = false;
      }
    }
