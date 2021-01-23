    private void OnDocumentBeforeSave(Document doc, ref bool saveAsUi, ref bool cancel)
    {
        // Ignore all spelling errors in the document
        foreach (Range error in this.application.ActiveDocument.SpellingErrors)
        {
            error.NoProofing = 1;
        }
        // Ignore all spelling errors in content controls
        foreach (ContentControl control in this.application.ActiveDocument.ContentControls)
        {
            control.Range.NoProofing = 1;
        }
    }
