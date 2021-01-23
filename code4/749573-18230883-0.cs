    private void Timer_Tick(object sender, EventArgs e)
    {
        DispatcherTimer timer = (DispatcherTimer)sender;
        if (++timerTickCount == 2)
        {
            if (hasSelectionChanged) timer.Stop();
            else MessageBox.Show("Hi there");
        }
    }
