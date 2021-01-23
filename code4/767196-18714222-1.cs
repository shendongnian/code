      private System.Windows.Forms.Timer timer1;
      public Form1()
      {
         InitializeComponent();
         timer1 = new System.Windows.Forms.Timer();
         timer1.Interval = 100;
         this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
         timer1.Enabled = true;
      }
      private void Form1_Load(object sender, EventArgs e)
      {
        // timer is triggered. code here is called
      }
