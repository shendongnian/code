     //Use ObservableCollection
     public ObservableCollection<MyData> MySource {get;set;}
     //initialize once, eg. ctor
     this.MySource = new ObservableCollection<MyData>();
     //add items
     this.MySource.Add(new MyData { id = 11123, title = "King", jobint = 1993123, lastrun = DateTime.Today, nextrun = DateTime.Today});
     //set the itemssource
     usedDataGrid.ItemsSource = this.MySource;
