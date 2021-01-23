	public abstract class ViewModelBase : INotifyPropertyChanged
	{
	   public event PropertyChangedEventHandler PropertyChanged;
	   public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
	   {
		  if (PropertyChanged != null)
			 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
	   }
	}
