    if (Application.Current.Dispatcher.CheckAccess()) 
    { 
         txtframeContainer.Text = Result; 
    } 
    else 
    { 
        Application.Current.Dispatcher.Invoke((Action)(() =>
        {
            txtframeContainer.Text = "Enter in diagnostic mode   SupplierSpecific --> Ok ";
        }));
    }
