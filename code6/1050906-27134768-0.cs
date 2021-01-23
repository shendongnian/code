                BackgroundWorker bw = new BackgroundWorker();
                ProgressBox prg = new ProgressBox("wErg", "Connecting to device...");
                bw.DoWork += (o, ea) =>
                {
                    //do stuff
                };
                bw.RunWorkerCompleted += (o, ea) =>
                {
                    prg.Close();
                };
                prg.Show();
                bw.RunWorkerAsync();
