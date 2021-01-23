    SpellingError spellingError = this.ctrl_RtfText.GetSpellingError(this.ctrl_RtfText.CaretPosition);
    if (spellingError != null && spellingError.Suggestions.Count() >= 1)
    {
        //Creating the suggestions menu items.
        foreach (string suggestion in spellingError.Suggestions)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = suggestion;
            menuItem.FontWeight = FontWeights.Bold;
            menuItem.Command = EditingCommands.CorrectSpellingError;
            menuItem.CommandParameter = suggestion;
            menuItem.CommandTarget = this.ctrl_RtfText;
            this.ctrl_RtfText.ContextMenu.Items.Insert(index, menuItem);
            index++;
        }
        Separator seperator = new Separator();
        this.ctrl_RtfText.ContextMenu.Items.Insert(index, seperator);
        index++;
        //Adding the IgnoreAll menu item
        MenuItem IgnoreAllMenuItem = new MenuItem();
        IgnoreAllMenuItem.Header = "Ignore All";
        IgnoreAllMenuItem.Command = EditingCommands.IgnoreSpellingError;
        IgnoreAllMenuItem.CommandTarget = this.ctrl_RtfText;
        this.ctrl_RtfText.ContextMenu.Items.Insert(index, IgnoreAllMenuItem);
        index++;
    }
    else
    {
        //No Suggestions found, add a disabled NoSuggestions menuitem.
        MenuItem menuItem = new MenuItem();
        menuItem.Header = "No Suggestions";
        menuItem.IsEnabled = false;
        this.ctrl_RtfText.ContextMenu.Items.Insert(index, menuItem);
        index++;
    }
    //.Net 4.0 Supports CustomDictionaries, Option for Adding to dictionary.
    TextPointer selectionStart = ctrl_RtfText.Document.ContentStart;
    if (!(this.ctrl_RtfText.Selection.IsEmpty))
    {
        Separator seperator1 = new Separator();
        this.ctrl_RtfText.ContextMenu.Items.Insert(index, seperator1);
        index++;
        MenuItem AddToDictionary = new MenuItem();
        AddToDictionary.Header = "Add to Dictionary";
        //Getting the word to add
        this.ctrl_RtfText.GetSpellingErrorRange(selectionStart);
        //Ignoring the added word.
        AddToDictionary.Command = EditingCommands.IgnoreSpellingError;
        AddToDictionary.CommandTarget = this.ctrl_RtfText;
        AddToDictionary.Click += (object o, RoutedEventArgs rea) =>
        {
            this.AddToDictionary(this.ctrl_RtfText.Selection.Text);
        };
        this.ctrl_RtfText.ContextMenu.Items.Insert(index, AddToDictionary);
        index++;
    }
    //REST OF THE CODE
