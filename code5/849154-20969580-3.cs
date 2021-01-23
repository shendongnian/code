	public abstract class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpresion)
		{
			var property = (MemberExpression)propertyExpresion.Body;
			this.OnPropertyChanged(property.Member.Name);
		}
		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
