           public int tootalsecs = 720 * 60;
           private void countdownTimer()
           {
             var startTime = DateTime.Now;
             var timer = new Timer() { Interval = 1000 };
           
             timer.Tick += (obj, args) =>
             {
                if (tootalsecs==0)
                {
                    timer.Stop();
                }
                else
                {
                    timerlabel1.Text =
                   (TimeSpan.FromMinutes(720) - (DateTime.Now - startTime))
                       .ToString("hh\\:mm\\:ss");
                    tootalsecs--;
                }
            };
                 timer.Start();
            }
