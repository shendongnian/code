		public object YourProperty
		{
			get
			{
				return yourProperty;
			}
			set
			{
				yourProperty = value;
				OnPropertyChanged();
				DateTime date;
				if(yourProperty is String && DateTime.TryParse((string) yourProperty, out date))
				{
					YourProperty = date;
				}
			}
		}
		private object yourProperty = string.Empty;
    //public Type YourPropertyType { get; set; }
