    protected override void OnBackKeyPress(CancelEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Teminate?","Do you want to exit the app.",MessageBoxButton.OKCancel);
            if (dialogResult == MessageBoxResult.OK)
            {
                Application.Current.Terminate();
            }
            else if (dialogResult == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
