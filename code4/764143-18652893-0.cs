    private readonly IWindowManager _windowManager;
    public void DisplayMessageBox()
    {
        _windowManager.ShowMetroMessageBox("Are you sure you want to delete...", "Confirm 
    Delete", MessageBoxButton.YesNo);
    }
