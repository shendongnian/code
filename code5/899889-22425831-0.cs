    class Class1 : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private string textBoxValue;
		public string TextBoxValue
		{
			get { return textBoxValue; }
			set
			{
				textBoxValue = value;
				updateList();
			}
		}
		private List<DataGridItem> dataGridItems;
		private List<DataGridItem> DataGridItems
		{
			get { return dataGridItems; }
			set
			{
				dataGridItems = value;
				PropertyChanged(this, new PropertyChangedEventArgs("DataGridItems"));
			}
		}
		private void updateList()
		{
			List<DataGridItem> newList = new List<DataGridItem>();
			//update the List
			DataGridItems = newList;
		}
	}
