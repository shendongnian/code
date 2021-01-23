    async Task PopulateInputFile(HtmlElement file)
    {
        file.Focus();
    
        // delay the execution of SendKey to let the Choose File dialog show up
        var sendKeyTask = Task.Delay(500).ContinueWith((_) =>
        {
            // this gets executed when the dialog is visible
            SendKeys.Send("C:\\Images\\CCPhotoID.jpg" + "{ENTER}");
        }, TaskScheduler.FromCurrentSynchronizationContext());
    
        file.InvokeMember("Click"); // this shows up the dialog
    
        await sendKeyTask;
        // delay continuation to let the Choose File dialog hide
        await Task.Delay(500); 
    }
    
    async Task Populate()
    {
        var elements = webBrowser.Document.GetElementsByTagName("input");
        foreach (HtmlElement file in elements)
        {
            if (file.GetAttribute("name") == "file")
            {
                file.Focus();
                await PopulateInputFile(file);
            }
        }
    }
