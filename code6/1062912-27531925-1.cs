    public Class A
    {
        public int ID;
        public string Name;
    }
    
    public Class B : A
    {
        public List<A> a = new List<A>();
    }
    
    Class ViewModel
    {
        public List<B> b = new List<B>();
    }
    
    Class Main
    {
        ViewModel _model = new ViewModel();
        //I want to set _model.b.a to List<A> variable
        ==> not sure what you want here ==> there is no _model.b.a since b is a list of A objects not an instance of B itself.
    }
