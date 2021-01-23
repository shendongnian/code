    public void OpenFile()
    {
        //Open Progress Bar Window
        LoadingWindow = new LoadingScreen(App.MainWindowViewModel.LoadScreen); 
        LoadingWindow.Show();
        App.MainWindowViewModel.LoadScreen.IsIndeterminate = true;
    
        FILE_INPUT = true; //bool that Signifies that the background thread is running
    
        //Create Thread -- run routines in thread
        Task.Factory.StartNew(() =>
        {
            openDefault(txtFile); //Passes the file
            //After thread has stopped running, close the window
            Dispatcher.Invoke(() => ViewModel.LoadingWindow.Close()); // -- Close Prog Bar
        });
    }
    private void OpenFile_Click(object sender, RoutedEventArgs e)
    {
        //calls to the method that launches the new thread and the window with the Progress Bar
        OpenFile();
    }
