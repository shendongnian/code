    public class CategoryModel
    {
        public string Name { get; set; }
        public int BookCount { get; set; }
    }
    public MainWindow()
    {
        BookCategories = new ObservableCollection<CategoryModel>();
        var doc = XDocument.Parse("path_to_Books.xml");
         // Loop through all <Category> nodes.
         foreach (var category in doc.Root.Elements("Category"))
         {
              // Count <Book> nodes within current <Category> node.
                var numberOfBooks = category.Elements("Book").Count();
               // Save the calculated quantity in the list.
                 BookCategories.Add(new CategoryModel { Name = category.Attribute("name").Value, BookCount = numberOfBooks });
          }
          InitializeComponent();
    }
  
     public ObservableCollection<CategoryModel> BookCategories { get; set; }
 
