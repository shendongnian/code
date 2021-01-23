            List<Status> statusList = new List<Status>();
            statusList.Add(new Status() { Value = 12, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 11, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 10, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 9, CreatedAt = "Sat Sep 27 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 8, CreatedAt = "Fri Sep 26 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 7, CreatedAt = "Thu Sep 25 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 6, CreatedAt = "Wed Sep 24 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 5, CreatedAt = "Tue Sep 23 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 4, CreatedAt = "Mon Sep 22 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 3, CreatedAt = "Sun Sep 21 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 2, CreatedAt = "Sat Sep 20 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Value = 1, CreatedAt = "Fri Sep 19 21:22:02 +0000 2014" });
            var groups = from status in statusList
                      let date = DateTime.ParseExact(status.CreatedAt, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture)
                      group status by date into g
                      where g.Key.Date >= DateTime.Now - new TimeSpan(7, 0, 0, 0)
                      select g;
            foreach (IGrouping<DateTime, Status> group in groups)
            {
                DateTime day = group.Key;
                int countOfValues = group.Select(g => g.Value).Count();
                Console.WriteLine("Day: {0}", day.ToString());
                Console.WriteLine("countOfValues: {0}", countOfValues.ToString());
            }
