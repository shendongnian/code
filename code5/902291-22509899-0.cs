    // the member to store our "set statecode" values; only for use in testing and mocking
    private AccountState? _statecode;
    // override and replace the base class statecode
    public new virtual AccountState? statecode
    {
        get { return _statecode; }
        // this is to get around the read-only of this field in the base class
        // the wrapper pretends to allow the statecode to be set, when it really does not stick on the actual Account entity
        set
		{ 
			_statecode = value;
			if(value == null){
				if(this.Attributes.Contains("statecode")){
					this.Attributes.Remove("statecode")
				}
			}
			else
			{
				this.SetAttributeValue("statecode", _statecode);
			}
		} 
    }
}
