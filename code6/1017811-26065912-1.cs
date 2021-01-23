     public ICollectionView MyViewOrderedByID {get;set;}
     public ICollectionView MyViewOrderedByIDReversed {get;set;}
     //ctor
     this.MyViewOrderedByID = CollectionViewSource.GetDefaultView(this.MySource);//default
     this.MyViewOrderedByID.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
     this.MyViewOrderedByIDReversed= new CollectionViewSource{ Source=this.MySource}.View;//new one
     this.MyViewOrderedByIDReversed.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Descending));
