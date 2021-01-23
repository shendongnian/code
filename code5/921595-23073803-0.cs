    protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
    {
    	PropertyChangedEventArgs ea = new PropertyChangedEventArgs(propertyName);
    	if (PropertyChanged != null)
    		PropertyChanged(this, ea);
    }
