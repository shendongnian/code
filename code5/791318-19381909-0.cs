    public Form1() {
      InitializeComponent();
      System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
      timer.Tick += timer_Tick;
      timer.Enabled = true;
    }
    void timer_Tick(object sender, EventArgs e) {
      if (this.Bounds.Contains(MousePosition)) {
        this.Text = "Inside";
      } else {
        this.Text = "Outside";
      }
    }
