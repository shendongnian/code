        private ListCollectionView groupedTypeRoutsView;
        public ListCollectionView GroupedTypeRoutsView
		{
			get
			{
                if (groupedTypeRoutsView == null)
				{
                    groupedTypeRoutsView = new ListCollectionView((IList)Routs);
                    groupedTypeRoutsView.GroupDescriptions.Add(new PropertyGroupDescription("Transport"));
				}
                return groupedTypeRoutsView;
			}
		}
       <ListBox ItemsSource="{Binding GroupedTypeRoutsView}" />
