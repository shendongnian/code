    private void spnl_tapped(object sender, TappedRoutedEventArgs e)
    {
         var vm=this.DataContext as ClassIWroteInViewModel; //get the view model
         vm.Tapped.Execute(null);//execute the command
    }
