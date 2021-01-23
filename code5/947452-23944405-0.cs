    <TextBox Text="{Binding Desc, ValidatOnErrors =True, Mode=TwoWay}" />
     public virtual string Desc 
    { 
        get { return _desc; }
        set {
            Contract.Requires(String.IsNullOrEmpty(value) == false);
            Contract.Requires(value.Length >2, "> 2 required ");
            _desc = value;
            NotifyOfPropertyChange(()=>Desc); //Added
        } 
    }
