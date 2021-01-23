    SpellingError spellingError = this.ctrl_RtfText.GetSpellingError(this.ctrl_RtfText.CaretPosition);
    if (spellingError != null)
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
            this.ctrl_RtfText.ContextMenu.Items.Add(menuItem);
        }
        if(this.ctrl_RtfText.ContextMenu.Items.Count == 0)
        {
             //No Suggestions found, add a disabled NoSuggestions menuitem.
             MenuItem menuItem = new MenuItem();
             menuItem.Header = "No Suggestions";
             menuItem.IsEnabled = false;
             this.ctrl_RtfText.ContextMenu.Items.Add(menuItem);
        }
        Separator seperator = new Separator();
        this.ctrl_RtfText.ContextMenu.Items.Add(seperator);
        //Adding the IgnoreAll menu item
        MenuItem IgnoreAllMenuItem = new MenuItem();
        IgnoreAllMenuItem.Header = "Ignore All";
        IgnoreAllMenuItem.Command = EditingCommands.IgnoreSpellingError;
        IgnoreAllMenuItem.CommandTarget = this.ctrl_RtfText;
        this.ctrl_RtfText.ContextMenu.Items.Add(IgnoreAllMenuItem);
        Separator seperator1 = new Separator();
        this.ctrl_RtfText.ContextMenu.Items.Add(seperator1);
        MenuItem AddToDictionary = new MenuItem();
        AddToDictionary.Header = "Add to Dictionary";
        //Getting the word to add
        var tr = this.ctrl_RtfText.GetSpellingErrorRange(this.ctrl_RtfText.CaretPosition);
        //Ignoring the added word.
        AddToDictionary.Command = EditingCommands.IgnoreSpellingError;
        AddToDictionary.CommandTarget = this.ctrl_RtfText;
        AddToDictionary.Click += (object o, RoutedEventArgs rea) =>
        {
            this.AddToDictionary(tr.Text);
        };
        this.ctrl_RtfText.ContextMenu.Items.Add(AddToDictionary);
    }
    //REST OF THE CODE
    
