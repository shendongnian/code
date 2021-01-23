    private void init()   
    {
        Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
        {
            // Background Thread
            Map map = new Map();
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new Action(() =>
                {
                    // Back to the UI Thread
                    var provider = new ApplicationIdCredentialsProvider("AsQ3bRJ8Ad9ENC4c67Aqpl6hywBXq_HT_zOwiSYRjOuRbmwwRHJQgWXXMVvHKkR_");
                    mapElementOnUI = new Map();
                    mapElementOnUI.CredentialsProvider = provider;
                    mapPanel.Children.Add(mapElementOnUI);
                    updateMapLocations();
                }));
        }
        ));
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
