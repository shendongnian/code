    public List<Fellow> fellowList { get; set; }
    private void PhoneApplicationPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
    fellowList = new List<Fellow>();
    
    for (int i = 0; i < 2; i++)
    {
        Fellow fellow = new Fellow();
        fellow.x = "B" + i;
        fellow.value = "B Value" + i;
        fellowList.Add(fellow);
    }
    this.DataContext = this;
    
    ListBoxItems.ItemsSource = fellowList;    
    
    }
    public class Fellow
    {
    public string x { get; set; }
    public string value { get; set; }
    }
