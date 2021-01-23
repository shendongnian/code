    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    
    class MyProcess
        {
    void OpenApplication(string myFavoritesPath)
            {
                // Start Internet Explorer. Defaults to the home page.
                
                Process.Start("IExplore.exe");
                
            }
    }
