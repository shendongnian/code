    private void FormatPastedTextCommandAction()
        {
            string paste = Clipboard.GetText();     // casting is not required if this function is used
    
            // Clipboard.SetText(paste);            // This line is reduntant
    
            PastedText += paste;                    // no need to call ToString()
    
            // Clipboard.Clear();                      // You should not clear the Clipboard, as the user may want to paste the data in some other window/application.
        }
