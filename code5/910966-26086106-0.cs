                   if (_adCst == null)
                   {
                _adCst = new AddCustomerPage();
                _adCst.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                _adCst.WindowState = System.Windows.WindowState.Normal;
                _adCst.ResizeMode = System.Windows.ResizeMode.NoResize;
                _adCst.Activate();  // This may need to be inside the block above
                _adCst.Show();
                   }
        
                  else
            {
                if (!_adCst.IsLoaded == true) 
                {
                    _adCst = new AddCustomerPage();
                    _adCst.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                    _adCst.WindowState = System.Windows.WindowState.Normal;
                    _adCst.ResizeMode = System.Windows.ResizeMode.NoResize;
                    _adCst.Show();
                }
            
                _adCst.Activate();
            }
