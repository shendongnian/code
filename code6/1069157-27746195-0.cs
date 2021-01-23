    private CollectionViewSource MySource { get; set; }
    
    private void PopulateView()
    {
        string[] fileNames = isf.GetDirectoryNames("Files/*.*");
        ItemCollection = new ObservableCollection<ItemProperties>();
        foreach (var Directory in fileNames)
        {
            // code which reads and loads the text files to string which then is added to the Collection
        }
        ItemCollection.Add(new ItemProperties { ID = a_ID, Title = a_Title});
        // Create view
        MySource = new CollectionViewSource {
            Source = ItemCollection
        };
        // Add sorting support
        MySource.View.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
        // Create a filter method
        MySource.View.Filter = obj => 
        {
            var item = obj as ItemProperties;
            // Predicate to determine if search box criteria met; change as needed
            return item.Title.Contains(txtMyFilter.Text);
        }
        // Set as ListBox source
        listBox1.ItemsSource = MySource;
    }
    // Bind to XAML TextBox element's KeyUp event or similar
    private void OnFilterKeyUp(object sender, KeyEventArgs e)
    {
        MySource.View.Refresh();
        // Include any other display logic here, such as possibly scrolling to top of ListBox
    }
