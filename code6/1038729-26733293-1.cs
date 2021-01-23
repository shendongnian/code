            int rowcount = dataGridView1.Rows.Count;
            List<Task> tasks = new List<Task>()
            for (int i = 0; i < rowcount; i++)
            {
               string filename = patch;
               var tsk = Task.Factory.StartNew(() =>
               {
                      try
                      {
                           WebClient webc = new WebClient();
                           webc.DownloadFile(dataGridView1.Rows[i].Cells[0].Value.ToString(), patch + "\\" + "alap" + (i+1).ToString() + ".mp4");
                      }
                      catch
                      {
                         //log
                      }
               });
               tasks.add(tsk);
            }
            Task.WaitAll(tasks);
