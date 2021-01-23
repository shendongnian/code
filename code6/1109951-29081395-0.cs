    private void itemSearchWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
    {
    	CboCustomerList.ItemsSource = e.Result as List<string>; 
        //busyIndicator.Visibility = System.Windows.Visibility.Hidden;
        busyIndicator.IsBusy = false;
    }
