    using System.Timers;
    Label l;
    private void updateClock(object source, ElapsedEventArgs e)
    {
        l.Invoke((MethodInvoker)(() =>
        {
            l.Text = String.Format("{0:hh:mm:ss tt}", DateTime.Now);
        }));
        
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        l = new Label();
        l.Location = new Point(5, 5);
        this.Controls.Add(l);
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Elapsed += updateClock;
        timer.Enabled = true;
        timer.AutoReset = true;
        timer.Interval = 1000;
        timer.Start();
    }
