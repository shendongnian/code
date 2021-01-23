    private void MONITOR2_DoWork(object sender, DoWorkEventArgs e)
    {
        oldClockNow = clockNow;
        //BP1
        clockThen = RunTime.ElapsedTicks;
        Thread.Sleep(1000);
        while (CONTINUE)
        {
            //BP2
            clockNow = RunTime.ElapsedTicks;
            TS = RunTime.Elapsed;
            MONITOR2.ReportProgress(0);
            oldClockNow = clockNow;
            //BP1
            clockThen = RunTime.ElapsedTicks;
            Thread.Sleep(1000);
        }
        RunTime.Stop();
    }
