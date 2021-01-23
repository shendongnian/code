    public sealed partial class Page2
    {
      public Page2() { InitializeComponent(); }
    
      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
        var argument = e.Parameter as IEnumerable<string>;
        listViewControl.ItemSource = argument;
      }
    
      private void GoBackToPreviousPage(object sender, RoutedEventArgs e)
      {
        Frame.GoBack();
      }
    }
