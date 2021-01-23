    class Class1 : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
                private List<OrderItem> allItems;
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
		private List<OrderItem> orderItems;
		private List<OrderItem> OrderItems
		{
			get { return orderItems; }
			set
			{
				orderItems= value;
				PropertyChanged(this, new PropertyChangedEventArgs("OrderItems"));
			}
		}
		private void updateList()
		{
			List<OrderItem> newList = new List<OrderItem>();
			//update the List
            foreach (OrderItem orderItem in allItems)
			{
				if (orderItem[name] == textBoxValue) newList.Add(orderItem);
			}
			OrderItems= newList;
		}
	}
