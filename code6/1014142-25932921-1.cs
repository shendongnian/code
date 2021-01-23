            for (int i = 0; i < 365; i++)
            {
                var tasks = db.Tasks.Where(x => x.Date.ToString("d") == DateTime.Now.AddDays(-i).ToString("d")).ToList();
                if (tasks.Count != 0)
                {
                    tempTask.AddRange(tasks);
                }
                else
                {
                    break;
                }
            }
