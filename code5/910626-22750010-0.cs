    using System.Net.NetworkInformation;
    ....
    
    protected virtual void OnNavigatedTo(NavigationEventArgs e)
    {
       bool isAvailable = NetworkInterface.GetIsNetworkAvailable();
    
       MessageBox.Show(isAvailable.ToString());
    }
