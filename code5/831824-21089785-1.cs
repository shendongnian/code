    { 
    ...
    _uiApp.Application.DocumentChanged += applicationOnDocumentChanged;
    _uiApp.ActiveUIDocument.PromptForFamilyInstancePlacement(family);
    _uiApp.Application.DocumentChanged -= applicationOnDocumentChanged;
    var el = document.GetElement(_addedElementIds[0]);
    ...
    }
    private void applicationOnDocumentChanged(object sender, DocumentChangedEventArgs documentChangedEventArgs)
    {
        if (documentChangedEventArgs.GetTransactionNames().Contains("Component"))
        {
            _addedElementIds.AddRange(documentChangedEventArgs.GetAddedElementIds());
            Press.Keys("" + (char)(int)Keys.Escape + (char)(int)Keys.Escape);
        }
    }
