    private MobileServiceCollection<Product, Product> _p;
    public MobileServiceCollection<Product, Product> P
    {
    	get { return _p; }
    	set 
    	{
    		_p = value;
    		NotifyPropertyChanged("P");
    	}
    }
