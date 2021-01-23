    public class ViewModel: INotifyPropertyChanged
	{
		private String text;
		public String Text
		{
			get
			{
				return this.text;
			}
			set
			{
				this.text = value;
				this.NotifyPropertyChanged("Text");
			}
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(String propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
	}
