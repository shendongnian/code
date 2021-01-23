    HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
            {
                if(NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                    e.Handled = true;
                }
            }
