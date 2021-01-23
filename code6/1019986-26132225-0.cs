            List<Status> statusList = new List<Status>();
            statusList.Add(new Status() { Id = 1, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Tue Sep 30 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Sat Sep 27 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Fri Sep 26 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Thu Sep 25 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Wed Sep 24 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Tue Sep 23 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Mon Sep 22 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Sun Sep 21 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Sat Sep 20 21:22:02 +0000 2014" });
            statusList.Add(new Status() { Id = 1, CreatedAt = "Fri Sep 19 21:22:02 +0000 2014" });
            var groups = from status in statusList
                      let date = DateTime.ParseExact(status.CreatedAt, "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.InvariantCulture)
                      group status by date into g
                      where g.Key.Date >= DateTime.Now - new TimeSpan(7, 0, 0, 0)
                      select g;
            foreach (IGrouping<DateTime, Status> group in groups)
            {
                DateTime day = group.Key;
                int sumOfIds = group.Select(g => g.Id).Sum(); //A total of something (just using id here)
                Console.WriteLine("Day: {0}", day.ToString());
                Console.WriteLine("sumOfIds: {0}", sumOfIds.ToString());
            }
