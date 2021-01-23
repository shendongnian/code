    public async Task Execute(string[] folderContent, CancellationToken token)
    {
        this.formatedFilenames = new Paragraph();
        if (folderContent.Length > 0)
        {
            for (int f = 0; f < folderContent.Length; ++f)
            {
                token.ThrowIfCancellationRequested();
                // yield to the Dispatcher message loop 
                // to keep the UI responsive
                await Dispatcher.Yield(DispatcherPriority.Background);                
                this.formatedFilenames.Inlines.Add(
                    new Run(folderContent[f] + Environment.NewLine));
                // don't do this: Thread.Sleep(500);
                // optionally, throttle it;
                // this step may not be necessary as we use Dispatcher.Yield
                await Task.Delay(500, token);
            }
        }
    }
