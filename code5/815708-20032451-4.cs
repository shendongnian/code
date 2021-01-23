        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this; // By setting itself to be it's own DataContext 
         // i can easily  bind to properties in my code behind (There are other ways but this is the most               correct and easy one.)
        }
                  
      
       private ObservableCollection<Example> _examples;
       public ObservableCollection<Example> Examples
       {
           get
           {
              if(_examples == null)
                   _examples = new ObservableCollection<Example>();
              return _examples; 
           } 
       }
       public void OnAddingItem()
       {
           Example newExample = new Example() { FolderPath = folderpath, Name = foldername, Prefix = foldername, Bin = false, Sign = false };
           Examples.Add(newExample); // Because Examples is an ObservableCollection it raises a    
        //CollectionChanged event when adding or removing items,
        // the ItemsControl (DataGrid) in your case corresponds to that event and creates a new container for the item ( i.e. new DataGridRow ).
       }
 
