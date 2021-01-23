    private decimal _YourCalculatedValue;
    public decimal YourCalculatedValue {return _YourCalculatedValue;}
    private void Calculate()
    {
        var awaiter = YourAsyncCalculation.GetAwaiter();
        awaiter.OnComplited(()=>
        {
         _YourCalculatedValue= (decimal)awaiter.GetResult();
         OnPropertyChanged("YourCalculatedValue"); // we calling a method which rising event
        });
    }
    // implementing of InotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
