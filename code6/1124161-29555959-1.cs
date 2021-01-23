    public class ArticleJSON
    {
    
        public string content { get; set; }
        public List<string> tags { get; set; }
        public string FormattedTags 
        {
           get
           {
              return string.Join(",", tags);
           }
        }
    
    }
 
            <ListBox Background="Black" x:Name="Test" ItemsSource="{Binding Items}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Foreground="Red" Text="{Binding FormattedTags}" />
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
