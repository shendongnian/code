    ObservableCollection<Person> Persons { get; set; }
    List<Person> MyList = new List<Person>(); 
    public ViewModel()
    {
        Persons = new ObservableCollection<Person>(MyList);
        ListCollectionView listCollectionView = CollectionViewSource.GetDefaultView(Persons) as ListCollectionView;
        if (listCollectionView != null)
        {
            listCollectionView.SortDescriptions.Clear();
            listCollectionView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }
    }
