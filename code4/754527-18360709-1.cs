    private void DockingManager_DocumentClosing(object sender, Xceed.Wpf.AvalonDock.DocumentClosingEventArgs e)
    {
        e.Document.CanClose = false;
        DocumentModel documentModel = e.Document.Content as DocumentModel;
        if (documentModel != null)
        {
            Dispatcher.BeginInvoke(
                new Action(() => this.Model.DocumentItems.Remove(documentModel)),
                DispatcherPriority.Background);
        }
    }
