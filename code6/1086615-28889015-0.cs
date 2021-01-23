    private void Application_DocumentChange()
    {
        // This event is fired every time the application sets a new active document, including
        // when the last active document is closed, in which case, Application.ActiveDocument
        // will be invalid.
        // Detect when a document has closed.
        // The previously active document is no longer active.  Check to see if the Doc object
        // is still valid.  If so, we can clear the IsClosing flag.  If not, we can assume it
        // was closed and queue it for post processing.
        if (_activeWrapper != null)
        {
            try
            {
                var lastDoc = _activeWrapper.Document();
                var path = lastDoc.FullName;
                _activeWrapper.IsClosing = false;  // set true in the close handler
            }
            catch (Exception ex)
            {
                if (_activeWrapper.IsClosing)
                {
                    // last document has closed
                    var path = RegistryTools.GetWordMRU(_appWrap.Version.ToString());
                    // do post-close processing on file
                }
                _activeWrapper.Dispose();
            }
        }
            
        Word.Document doc = null;
        DocWrapper wrapper = null;
        try
        {
            doc = Application.ActiveDocument; //will throw exception on last close
        }
        catch (Exception ex)
        {
            //if this exception is due to an invalid active document, then we can treat the
           //event as an indication that the last document has closed.
           return;  // WORD Closing
        }
        // remember the current active document
        if(doc != null)
            wrapper = DocWrapper.GetWrapper(doc);
        _activeWrapper = wrapper;
    }
