    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        bgWorker.DoWork += LoadIcons;
        bgWorker.ProgressChanged += IconDone;
        bgWorker.RunWorkerAsync();
    }
    
    private void IconDone(object sender, ProgressChangedEventArgs e)
    {
        Icon icon = e.UserState as Icon;
        if (icon != null)
            WrapPanel.Children.Add(icon); //This code is executed in the GUI thread
    }
    
    private void LoadIcons(object sender, DoWorkEventArgs doWorkEventArgs)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
        //Populate ListOfSVGsInFolder
        foreach (String SVGFile in ListOfSVGsInFolder)
        {
            Icon icon = new Icon
    
            //Perform ~50 lines of code which get the paths and other details from the
            //SVGFile and plug them into my icon object
    
            //Now I had a fully generated Icon
    
    
            worker.ReportProgress(0, icon);
        }
    }
