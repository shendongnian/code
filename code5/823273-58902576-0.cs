    private ObservableCollection<ListingGridRow> _rowDataStoreAsList;
    public GenericCollectionView<ListingGridRow> TypedCollectionView
    {
      get => _typedCollectionView;
      set { _typedCollectionView = value; OnPropertyChanged();}
    }
    public void FullRefresh()
	{
		var listData = _model.FetchListingGridRows(onlyListingId: -1);
		_rowDataStoreAsList = new ObservableCollection<ListingGridRow>(listData);
		var oldView = TypedCollectionView;
		var saveSortDescriptions = oldView.SortDescriptions.ToArray();
		var saveFilter = oldView.Filter;
		TypedCollectionView = new GenericCollectionView<ListingGridRow>(new ListCollectionView(_rowDataStoreAsList));
		var newView = TypedCollectionView;
		foreach (var sortDescription in saveSortDescriptions)
		{
			newView.SortDescriptions.Add(new SortDescription()
			{
				Direction = sortDescription.Direction,
				PropertyName = sortDescription.PropertyName
			});
		}
		newView.Filter = saveFilter;
	}
	internal void EditItem(object arg)
	{
		var view = TypedCollectionView;
		var saveCurrentPosition = view.CurrentPosition;
		var originalRow = view.TypedCurrentItem;
		if (originalRow == null)
			return;
		var listingId = originalRow.ListingId;
		var rawListIndex = _rowDataStoreAsList.IndexOf(originalRow);
		// ... ShowDialog ... DialogResult ...
		var lstData = _model.FetchListingGridRows(listingId);
		_rowDataStoreAsList[rawListIndex] = lstData[0];
		view.MoveCurrentToPosition(saveCurrentPosition);
		view.Refresh();
	}
