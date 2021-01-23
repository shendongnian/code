    private void MONITOR2_DoWork(object sender, DoWorkEventArgs e)
    {
        if(CONTINUE)
        {
            oldClockNow = clockNow;
            //BP1
            clockThen = RunTime.ElapsedTicks;
            Thread.Sleep(1000);
            while (true)
            {
                //BP2
                clockNow = RunTime.ElapsedTicks;
        
                TS = RunTime.Elapsed;
        
                MONITOR2.ReportProgress(0);
                if(!CONTINUE)
                    break;
        
                oldClockNow = clockNow;
                //BP1
                clockThen = RunTime.ElapsedTicks;
                Thread.Sleep(1000);
            }
        }
        RunTime.Stop();
    }
