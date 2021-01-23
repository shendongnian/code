    private void AddButtonToAppBar()
    {
        AppBarButton buttonToAdd = new AppBarButton { Label = "Label", Icon = new SymbolIcon(Symbol.Help) };
        buttonToAdd.Click += async (sender, e) =>  await new MessageDialog("Button clicked").ShowAsync();
        // add button to Page's BottoAppBar
        (BottomAppBar as CommandBar).PrimaryCommands.Add(buttonToAdd);
    }
