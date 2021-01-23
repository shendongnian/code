    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // initialize defaults
        bool isRestarted = false;
        label1.Content = "";
        label2.Content = "";
        // Check the state
        if (stateFile.Exists) // stateFile is something like type FileInfo
        {
            var text = File.ReadAllText(stateFile.FullName);
            isRestarted = ParseForBool(text);
            label1.Content = ParseForLabel(text); // if you want that to be restored as well
        }
        if (isRestarted)
        {
            label2.Content = "After restart";
            DoSomeMagicRemoveAutostart(); // just if you want to restart only once
        }
        else
        {
            label1.Content = "Before restart";
            stateFile.Write(true); // is restarted
            stateFile.Write(label1.Content); // if you want to restore that as well
            DoSomeMagicAutoStartOperation(); // TODO: Autostart folder or Registry key
            System.Diagnostics.Process.Start("ShutDown", "-r"); //restart
        }
    }
