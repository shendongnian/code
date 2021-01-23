   	private ICollectionView _baseView;
	public ICollectionView BaseView
	{
		get
		{
			if (_baseView == null)
			{
				_baseView = new ListCollectionView((IList) items);
				_baseView.Filter = o => o is Group || o is Item && (o as Item).GroupId != Guid.Empty;					
			}
			return _baseView;
		}
	}
   
    
