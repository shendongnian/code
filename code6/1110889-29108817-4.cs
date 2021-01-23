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
        Generate_.BeginInvoke((Action)delegate()
        {
            Generate_.Enabled = true;
        });
    }
