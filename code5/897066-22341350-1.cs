    public ItemInAListBoxViewModel(MainWindowViewModel mainWindow)
    {
        this.window = mainWindow;
        Activator = new ViewModelActivator();
        // This gets called every time the View for this VM gets put on screen
        this.WhenActivated(d => {
            // The 'd' is for "Dispose this when you're Deactivated"
            d(this.WhenAnyValue(x => x.window.IsMinimized)
                .Where(x => x == true)
                .Subscribe(x => this.IsSelected = false));
        });
    }
