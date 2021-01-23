    public void DockingManager_DocumentClosed(DocumentClosedEventArgs e)
            {
                Models.Documents.Document doc = e.Document.Content as Models.Documents.Document;
                DocumentSources.Remove(doc);
            }
