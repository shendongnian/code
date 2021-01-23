     public ICollectionView MyViewOrderedByID {get;set;}
     public ICollectionView MyViewOrderedByIDReversed {get;set;}
     //ctor
     this.MyViewOrderedByID = new CollectionViewSource{ Source=this.MySource}.View;
     this.MyViewOrderedByID.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
     this.MyViewOrderedByIDReversed= CollectionViewSource.GetDefaultView(this.MySource);
     this.MyViewOrderedByIDReversed.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Descending));
