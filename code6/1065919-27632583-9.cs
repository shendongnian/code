    private void spnl_Tapped(object sender, TappedRoutedEventArgs e)
    {
         var vm=this.DataContext as ClassIWroteInViewModel; //get the view model
         vm.TapCommand.Execute(null);//execute the command
    }
