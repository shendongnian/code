        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (_lockObj)
            {
                if (!timer.Enabled)
                    return;
                isTimerElapsedHandlerExecuting = true;
            }
            try
            {
                if (mode == Mode.Group1)
                    displayGroup1();
                else if (mode == Mode.Group2)
                    displayGroup2();
                else if (mode == Mode.Group3)
                    displayGroup3();
            }
            finally
            {
                isTimerElapsedHandlerExecuting = false;
            }
        }
