    public class ItemViewModel : INotifyPropertyChanged
    {
      public Uri GotoUri {get; set;}
      //...
    }
    private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       var si = MainLongListSelector.SelectedItem as PivotApp3.ViewModels.ItemViewModel;
           if(si != null)
           NavigationService.Navigate(si.GotoUri, UriKind.Relative));
    }
