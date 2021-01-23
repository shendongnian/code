    public async Task Execute(string[] folderContent, CancellationToken token)
    {
        this.formatedFilenames = new Paragraph();
        if (folderContent.Length > 0)
        {
            for (int f = 0; f < folderContent.Length; ++f)
            {
                token.ThrowIfCancellationRequested();
                this.formatedFilenames.Inlines.Add(
                    new Run(folderContent[f] + Environment.NewLine));
                // don't do this: Thread.Sleep(500);
                // instead, yield to the Dispatcher message loop 
                // to keep the UI responsive
                await Dispatcher.Yield(DispatcherPriority.Background);                
                // optionally, throttle it;
                // the above step may not be necessary then
                await Task.Delay(500);
            }
        }
    }
