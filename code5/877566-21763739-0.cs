    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        Action action = () =>
        {
            this.rtbFolderContent.Document.Blocks.Clear();
            // the next line causes InvalidOperationsException:
            // The calling thread cannot access this object because a different thread owns it.
            this.rtbFolderContent.Document.Blocks.Add((Paragraph)e.Result);
        };
        Dispatcher.Invoke(DispatcherPriority.Normal, action);
    }
