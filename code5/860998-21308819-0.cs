		private List<TestCategories>_myItemSourceList;
		public List<TestCategories> MyItemSourceList
		{
			get { return _myItemSourceList; }
			set
			{
				if (value != _myItemSourceList)
				{
					_myItemSourceList= value;
					RaisePropertyChanged(() => MyItemSourceList);
				}
			}
		}
