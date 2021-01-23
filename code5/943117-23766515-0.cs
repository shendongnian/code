    DateTime runTime;
    public Form1() {
      InitializeComponent();
      DateTime nowTime = DateTime.Now;
      runTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 12, 0, 0);
      timer1.Interval = 500;
    }
    void timer1_Tick(object sender, EventArgs e) {
      if (DateTime.Now > runTime) {
        timer1.Stop();
        MessageBox.Show("It's time!");
      }
    }
    void button1_Click(object sender, EventArgs e) {
      timer1.Start();
    }
