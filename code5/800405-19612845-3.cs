    public void button1_Click(object sender, EventArgs e)
    {
        var timer = new System.Windows.Forms.Timer { Interval = 5000 };
        timer.Tick += delegate
        {
            timer.Dispose();
            kruispunt.zPad1.voetstoplicht1.setStatus(StoplichtStatus.Rood);
            kruispunt.zPad1.voetstoplicht2.setStatus(StoplichtStatus.Rood);
            this.Refresh();
        }
        timer.Start();
    }
