    using Microsoft.Phone.Net.NetworkInformation;
    private void CheckInetConnection()
    {
        if (NetworkInterface.GetIsNetworkAvailable() == true)
        {
            //Internet avalaible
        }
        else
        {
           //No connection available
        }
    }
