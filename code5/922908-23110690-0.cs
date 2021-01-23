    BackgroundWorker bgw = new BackgroundWorker();
    bgw.DoWork += bgw_DoWork;
    bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
    progressBar1.Style = ProgressBarStyle.Marquee;
    progressBar1.MarqueeAnimationSpeed = 50;
    bgw.RunWorkerAsync();
    void bgw_DoWork(object sender, DoWorkEventArgs e) {
      // long work
    }
    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      progressBar1.Style = ProgressBarStyle.Continuous;
      progressBar1.MarqueeAnimationSpeed = 0;
    }
