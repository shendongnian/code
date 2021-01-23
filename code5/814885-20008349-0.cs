        TimeSpan currentTime = DateTime.Now.TimeOfDay;
        TimeSpan earliest = new TimeSpan(1, 30, 0); // 1:30 AM
        TimeSpan latest   = new TimeSpan(1, 40, 0); // 1:40 AM
        if (currentTime >= earliest && currentTime <= latest)
        {
            // Do Something.
        }
