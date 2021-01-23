    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
         string selectedItem = null;
    
         if (this.NavigationContext.QueryString.ContainsKey("SelectedItem"))
         {
              selectedItem = this.NavigationContext.QueryString["SelectedItem"];
         }
    
         if (selectedItem != null)
         {
              DataContext = App.ViewModel.Items.Where(p => string.Compare(selectedItem, p.ID) == 0).FirstOrDefault();
         }
    }
