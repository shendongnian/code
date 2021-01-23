    public void runTimerTick(object sender, EventArgs e)
    {
        TimeSpan currentExamTime = DateTime.Now - examStartTime;
        if (currentExamTime > totalExamTime)
        {
            MessageBox.Show("Exam Time is Finished");
            runTimer.Stop();
            runTimer.Tick -= new EventHandler(runTimerTick);
            runTimer.Dispose();
        }
    }
    
