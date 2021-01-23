    <ProgressBar Name="pb1" IsIndeterminate="True" Visibility="True" />
    void theBrowser_Navigated(object sender, NavigationEventArgs e)
    {
        //Console.WriteLine("Webpage Loaded !!");
        pb1.Visibility = Visibility.Collapsed;
    }
