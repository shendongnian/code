    System.Win32.OpenFileDialog dialog = new System.Win32.OpenFileDialog()
    {
        AddExtension = true,
        CheckPathExists = true,
        DefaultExt = ".xaml",
        Filter = "Xaml files (.xaml)|*xaml|All files|*.*",
        FilterIndex = 0
    };
    private void FileOpen()
    {
        Boolean? result = dialog.ShowDialog();
        if (result.HasValue && result.Value)
        {
            // business logic
        }
    }
