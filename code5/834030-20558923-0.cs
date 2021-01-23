    public class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public RelayCommand OnClickedCommand { get; private set; }
		private bool _ImageChanged;
		public bool ImageChanged
		{
			get { return this._ImageChanged; }
			private set {
				this._ImageChanged = value;
				OnPropertyChanged("ImageChanged");
			}
		}
		public ViewModel()
		{
			this.OnClickedCommand = new RelayCommand(param => OnClicked());
		}
		private void OnClicked()
		{
			this.ImageChanged = true;
		}
	}
