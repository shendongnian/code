    public abstract class ObservableObject : INotifyPropertyChanged
	{
		protected ObservableObject()
		{
		}
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
		protected void SetValue<T>(ref T refValue, T newValue, Expression<Func<T>> propertyExpresion)
		{
			if (!object.Equals(refValue, newValue))
			{
				refValue = newValue;
				this.OnPropertyChanged(propertyExpresion);
			}
		}
		protected void SetValue<T>(ref T refValue, T newValue, Action valueChanged)
		{
			if (!object.Equals(refValue, newValue))
			{
				refValue = newValue;
				valueChanged();
			}
		}
		protected void SetValue<T>(ref T refValue, string propertyName, T newValue)
		{
			if (!object.Equals(refValue, newValue))
			{
				refValue = newValue;
				this.OnPropertyChanged(propertyName);
			}
		}
	}
