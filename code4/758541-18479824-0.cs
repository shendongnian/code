    private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
            {
                MessageBoxResult mRes = MessageBox.Show("Would you like to exit?", "Exit", MessageBoxButton.OKCancel);
                if (mRes == MessageBoxResult.OK)
                {
                    NavigationService.GoBack();
                }
                if (mRes == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
