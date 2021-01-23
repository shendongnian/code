            DateTime dt = DateTime.Now;
            DateTime dt1 = DateTime.Now.AddDays(1);
            TimeSpan duration = dt1 - dt;
            long durationTicks = Math.Abs(duration.Ticks / TimeSpan.TicksPerMillisecond);
            long hours = durationTicks / ( 1000 * 60 * 60);
            long minutes = (durationTicks - (hours * 60 * 60 *1000 )) / (1000 * 60);
            
            System.Console.WriteLine(hours.ToString("00") + ":" + minutes.ToString("00"));
