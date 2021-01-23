    private bool _isComparisonRun;
    public bool IsComparisonRun
    {
    	get { return _isComparisonRun; }
    	set
    	{
    		if (_isComparisonRun == value) return;
    		_isComparisonRun = value;
    		RaisePropertyChanged(() => IsComparisonRun);
    	}
    }
