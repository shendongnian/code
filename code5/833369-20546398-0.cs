    public void Start(object obj)
    {
        try
        {
            BackgroundWorker previousWorker = null;
            DataHolderClass previousWorkerParams = null;
            foreach (KeyValuePair<string, Stream> pair in this.CollectionOfFiles)
            {
                // signal event on previous worker RunWorkerCompleted event
                AutoResetEvent waitUntilCompleted = null;
                if (previousWorker != null)
                {
                    waitUntilCompleted = new AutoResetEvent(false);
                    previousWorker.RunWorkerCompleted += (o, e) => waitUntilCompleted.Set();
                    // start the previous worker
                    previousWorker.RunWorkerAsync(previousWorkerParams);
                }
                Worker = new BackgroundWorker();
                Worker.DoWork += (o, e) =>
                {
                    // wait for the handle, if there is anything to wait for
                    if (waitUntilCompleted != null)
                    {
                        waitUntilCompleted.WaitOne();
                        waitUntilCompleted.Dispose();
                    }
                    worker_DoWork(o, e);
                };
                using (Stream stream = pair.Value)
                {
                    primaryDocument = new Document(stream);
                    DataHolderClass dataHolder = new DataHolderClass();
                    dataHolder.FileName = pair.Key;
                    dataHolder.Doc = secondaryDocument;
                    // defer running this worker; we don't want it to finish
                    // before adding additional completed handler
                    previousWorkerParams = dataHolder;
                }
                previousWorker = Worker;
            }
            if (previousWorker != null)
            {
                previousWorker.RunWorkerAsync(previousWorkerParams);
            }
        }
        catch (Exception ex)
        {
            // exception logic
        }
        finally
        {
            // complete logic
        }
    }
