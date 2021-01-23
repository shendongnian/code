    int ticks = 0;
    void dispatcherTimer2_Tick(object sender, object e)
            {
                ticks++;
                tb2.Text = ticks.ToString();
                if (ticks == 12)
                {
                    mp.Play();
                    //dispatcherTimer.Start();
                    ticks = 0;
                }
            }
