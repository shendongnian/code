    public void ThreadWork()
    {
        while (true)
        {
            if (currValue_ >= maxValue_)
                break;
            ThreadTick();
        }
        mb_.StopBrot();
        t_.Interrupt();
        MessageBox.Show("Finished!");
        Application.Current.Dispatcher.BeginInvoke((Action)delegate()
        {
            Generate_.Enabled = true;
        });
    }
