    public class Country
    {
		public string Name { get; set; }
		public string President { get; set; }
    }
    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	//currentItem is a variable specified in General class
		//Also in this example, i supposed you have country class that contains information about a country
    	//Use Country.Name to get name of selected country
		General.currentItem = (Country)ListView.SelectedItem;
		NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
    }
