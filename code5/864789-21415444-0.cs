    public string ShowWPFApp(string person)
    {
        returnResults = null;
        mainWindow.LoadPerson(person);
        mainWindow.Show();
        Dispatcher.CurrentDispatcher.Run();
        // do whatever to get the results
        return returnResults;
    }
