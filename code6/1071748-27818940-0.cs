    private void Grid_Loaded(object sender, RoutedEventArgs e)
    {
        Thread t = new Thread(LoadIcons);
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
    }
    private void LoadIcons()
    { 
        Dispatcher.Invoke(new Action(() => 
        {
            foreach(Icon present in directory)
            { 
                present.Width = 16;
                present.Height = 16;
                pnlIcons.Width = 50;
                pnlIcons.Children.Add(present);
            }
        }));
    }  
