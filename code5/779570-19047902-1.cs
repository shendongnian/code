            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                // do something long running
                for (int i = 1; i <= records.Count; i++)
                {
                    DisplayMessage("process " + i + " of " + records.Count);
                    ProcessRecord(records[i]);
                }
            };
            worker.RunWorkerCompleted+= (s, e) =>
            {
                // report to user
            };
            worker.RunWorkerAsync();
