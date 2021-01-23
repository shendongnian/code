    public MainClass()
    {
		// private backing field is only accessible within this class
        private ChildClass _cc = new ChildClass();
        
		// public property is accessible from other classes
        public ChildClass cc 
        { 
            get 
			{
			    return _cc;
			}
			set
			{
			    _cc = value;
			}
        }
    }
