     public void ExtractFile(string zipToUnpack, string unpackDirectory)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = true;
        worker.ProgressChanged += (o, e) { .... };
        worker.DoWork += (o, e) =>
        {
            using (ZipFile zip = ZipFile.Read(zipToUnpack))
            {  
                int step = (zip.Count / 100.0);
                int percentComplete = 0;
                foreach (ZipEntry file in zip)
                {
                    file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    percentComplete += step;
                    worker.ReportProgress(percentComplete);
                }
            }
        };
    
        worker.RunWorkerAsync();
    }
