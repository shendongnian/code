            for (int i = 0; i < 365; i++)
            {
                var tasks = db.Tasks.Where(x => x.Date.AddDays(-i).ToString("d") == DateTime.Now.AddDays(-i).ToString("d")).ToList();
                if (tasks != null)
                {
                    tempTask.AddRange(tasks);
                }
                else
                {
                    break;
                }
            }
