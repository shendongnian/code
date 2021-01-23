    private static void LoadSystemWindowsInteractivity()
    {
        // HACK: Force load System.Windows.Interactivity.dll from plugin's 
        // directory
        typeof(System.Windows.Interactivity.Behavior).ToString();
    }
    static MyEditorFactory()
    {
        LoadSystemWindowsInteractivity();
    }
