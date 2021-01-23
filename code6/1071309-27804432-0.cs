    void simulare_Load(object sender, EventArgs e)
    {
        var startTime = DateTime.Now;
        timer = new System.Windows.Forms.Timer() { Interval = 1000 };
        timer.Tick += (obj, args) =>
        {
            TimeSpan ts = TimeSpan.FromMinutes(0.1) - (DateTime.Now - startTime);
            label1.Text = ts.ToString("hh\\:mm\\:ss");
            if (ts.Seconds == 0)
            {
                timer.Stop();
                MessageBox.Show("Done!");
            }
        };
        timer.Start();
    }
