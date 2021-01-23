            DispatcherTimer timer ;
            // When application is started
            if (DateTime.Now.Hour == 16)
            {
                // Start your task
            }
            else
            {
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 1, 0);
                timer.Tick += timer_Tick;
                timer.Start();
            }
