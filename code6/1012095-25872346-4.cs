    Thread t = new Thread(new ThreadStart(UpdateLabelThreadProc));
    t.Start();
    
    bool isPlaying = false;
    void UpdateLabelThreadProc()
    {
        while (isPlaying)
        {
            this.BeginInvoke(new MethodInvoker(UpdateLabel));
            System.Threading.Thread.Sleep(1000);
        }
    }
    private void UpdateLabel()
    {
        lblVoiceDuration.Text = wmpPlayer.Ctlcontrols.currentPositionString;
    }
