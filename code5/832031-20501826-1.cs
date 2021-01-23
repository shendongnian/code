    private void Form1_Load(object sender, EventArgs e)
        {
            Timer t1 = new Timer();
            t1.Tick += t1_Tick;
            t1.Interval = 5000; //5000 ms = 5 seconds
            t1.Start();
        }
        void t1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            t1.Stop(); //it should be stopped after hiding the form
        }
