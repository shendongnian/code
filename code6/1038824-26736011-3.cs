    public static string TileString(int x, int y, int z)
    {
        ...
        Application.Current.Dispatcher.Invoke(new Action(() =>
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.AppendServerOutput(tileString);
        }));
    }
