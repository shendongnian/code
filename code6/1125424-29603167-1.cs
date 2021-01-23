    private void Start(object sender, RoutedEventArgs e)
        {
     progress.Minimum = 0;
                progress.Maximum = 100;
            worker.RunWorkerAsync();
        }
 
    BackgroundWorker bg = sender as BackgroundWorker;
                FileInfo fi = new FileInfo(@"File");
                length = fi.Length;
    
                int percent;
    
    
                using (StreamReader sr = new StreamReader(@"File", System.Text.Encoding.ASCII))
                {
                    while (sr.EndOfStream == false)
                    {
                        line = sr.ReadLine();
                        file.Add(line);
                        currentPosition += line.Count();
    
                        percent = (int)(currentPosition / length) * 100;
                        bg.ReportProgress(percent);
                        Thread.Sleep(100);
                    }
                }
