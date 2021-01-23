     private void brnPrint_Click(object sender, EventArgs e)
            {
                var files = Directory.GetFiles(@"D:\Folder", "*.jpg");
    
                foreach (var i in files)
                {
                    var objPrintDoc = new PrintDocument();
                    objPrintDoc.PrintPage += (obj, eve) =>
                        {
                            Image img = Image.FromFile(i);
                            Point loc = new Point(100, 100);
                            eve.Graphics.DrawImage(img, loc);
                        };
                    
                    objPrintDoc.Print();
                    PrintServer myPrintServer = new PrintServer(@"\\ComputerName");
                    PrintQueueCollection myPrintQueues = myPrintServer.GetPrintQueues();                   
                    try
                    {
                        foreach (PrintQueue pq in myPrintQueues)
                        {
                            pq.Refresh();
                            PrintJobInfoCollection pCollection = pq.GetPrintJobInfoCollection();
                            foreach (PrintSystemJobInfo job in pCollection)
                            {
                                listBox1.Items.Add(pq.Name);
                                SpotTroubleUsingJobAttributes(job);
                            }
    
                        }
                    }
                    catch (Exception)
                    {
                         //throw;
                    }
                }
            }
    
            public void SpotTroubleUsingJobAttributes(PrintSystemJobInfo theJob)
            {
                if ((theJob.JobStatus & PrintJobStatus.Blocked) == PrintJobStatus.Blocked)
                {
                    listBox1.Items.Add("The job is blocked.");
                }
                if (((theJob.JobStatus & PrintJobStatus.Completed) == PrintJobStatus.Completed)
                    ||
                    ((theJob.JobStatus & PrintJobStatus.Printed) == PrintJobStatus.Printed))
                {
                    listBox1.Items.Add(
                        "The job has finished. Have user recheck all output bins and be sure the correct printer is being checked.");
                }
                if (((theJob.JobStatus & PrintJobStatus.Deleted) == PrintJobStatus.Deleted)
                    ||
                    ((theJob.JobStatus & PrintJobStatus.Deleting) == PrintJobStatus.Deleting))
                {
                    listBox1.Items.Add(
                        "The user or someone with administration rights to the queue has deleted the job. It must be resubmitted.");
                }
                if ((theJob.JobStatus & PrintJobStatus.Error) == PrintJobStatus.Error)
                {
                    listBox1.Items.Add("The job has errored.");
                }
                if ((theJob.JobStatus & PrintJobStatus.Offline) == PrintJobStatus.Offline)
                {
                    listBox1.Items.Add("The printer is offline. Have user put it online with printer front panel.");
                }
                if ((theJob.JobStatus & PrintJobStatus.PaperOut) == PrintJobStatus.PaperOut)
                {
                    listBox1.Items.Add("The printer is out of paper of the size required by the job. Have user add paper.");
                }
    
                //if (((theJob.JobStatus & PrintJobStatus.Paused) == PrintJobStatus.Paused)
                //    ||
                //    ((theJob.HostingPrintQueue.QueueStatus & PrintQueueStatus.Paused) == PrintQueueStatus.Paused))
                //{
                //    HandlePausedJob(theJob);
                //    //HandlePausedJob is defined in the complete example.
                //}
    
                if ((theJob.JobStatus & PrintJobStatus.Printing) == PrintJobStatus.Printing)
                {
                    listBox1.Items.Add("The job is printing now.");
                }
                if ((theJob.JobStatus & PrintJobStatus.Spooling) == PrintJobStatus.Spooling)
                {
                    listBox1.Items.Add("The job is spooling now.");
                }
                if ((theJob.JobStatus & PrintJobStatus.UserIntervention) == PrintJobStatus.UserIntervention)
                {
                    listBox1.Items.Add("The printer needs human intervention.");
                }
    
            }
