    public class GridItem {
      public string Content{ get; set; }
    }
....
    List<string> DateIntervaList = new List<string>();
    
    DateIntervaList.Add( new GridItem(){ Content = "1" } );
    DateIntervaList.Add( new GridItem(){ Content = "2" } );
    DateIntervaList.Add( new GridItem(){ Content = "11" } );
    DateIntervaList.Add( new GridItem(){ Content = "12" } );
    Grid.ItemsSource = DateIntervalList; 
