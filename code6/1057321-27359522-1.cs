        void DoWork(int durationInMinutes)
        {
            DateTime startTime = DateTime.UtcNow;
            TimeSpan breakDuration = TimeSpan.FromMinutes(durationInMinutes);
            // option 1
            while (DateTime.UtcNow - startTime < breakDuration)
            {
                // do some work
            }
            // option 2
            while (true)
            {
                // do some work
                if (DateTime.UtcNow - startTime > breakDuration)
                    break;
            }
        }
