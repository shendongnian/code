    void DoWork(int durationInMinutes)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan breakDuration = TimeSpan.FromMinutes(durationInMinutes);
            // option 1
            while (DateTime.Now - startTime < breakDuration)
            {
                // do some work
            }
            // option 2
            while (true)
            {
                // do some work
                if (DateTime.Now - startTime > breakDuration)
                    break;
            }
        }
