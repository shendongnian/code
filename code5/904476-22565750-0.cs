    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
		private string normallyOpenString = "I'm an open string!";
		public string NormallyOpenString
		{
			get { return normallyOpenString; }
			set
			{
				normallyOpenString = value;
				RaisePropertyChanged("NormallyOpenString");
			}
		}        
    }
