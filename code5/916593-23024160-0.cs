    //http://msdn.microsoft.com/en-us/library/ms752914(v=vs.110).aspx
    
    public static readonly DependencyProperty PropertyProperty = 
    DependencyProperty.Register(
    "Property", typeof(Boolean),
    );
    public bool IsSpinning
    {
    get { return (bool)GetValue(PropertyProperty ); }
    set { SetValue(PropertyProperty , value); }
    }
