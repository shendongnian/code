    private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       var si = MainLongListSelector.SelectedItem as PivotApp3.ViewModels.ItemViewModel;
           
        if(si.LineOne.Equals("+ To Do List"))
           NavigationService.Navigate(new Uri("/todolistPage.xaml", UriKind.Relative));
        else if(si.LineOne.Equals("another"))
           NavigationService.Navigate(new Uri("/another.xaml", UriKind.Relative));
    }
