    void timer_Tick(object sender, EventArgs e) {
      progressBar1.PerformStep();      
    }
    void button1_MouseDown(object sender, MouseEventArgs e) {
      timer.Start();
    }
    void button1_MouseUp(object sender, MouseEventArgs e) {
      timer.Stop();
    }
