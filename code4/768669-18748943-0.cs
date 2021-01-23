       MessageBoxResult result = 
                          MessageBox.Show(
                            msg, 
                            "Data App", 
                            MessageBoxButton.YesNo, 
                            MessageBoxImage.Warning);
                        if (result == MessageBoxResult.No)
                        {
                            // If user doesn't want to close, cancel closure
                            e.Cancel = true;
                        }
