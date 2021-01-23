        public MainWindow()
        {
            InitializeComponent();
            var itemSource = new System.Collections.ObjectModel.ObservableCollection<CustomComboboxItem>();
            itemSource.Add(new CustomComboboxItem {NewItemName = "Item 1", NewItemComment = "hello :)"});
            itemSource.Add(new CustomComboboxItem {NewItemName = "Item 2", NewItemComment = "hello :)"});
            itemSource.Add(new CustomComboboxItem {NewItemName = "Item 3", NewItemComment = "hello :)"});
            itemSource.Add(new CustomComboboxItem {NewItemName = "Item 4", NewItemComment = "hello :)"});
            itemSource.Add(new CustomComboboxItem {NewItemName = "Item 5", NewItemComment = "hello :)"});
            comboBox1.ItemSource = itemSource;
        }
