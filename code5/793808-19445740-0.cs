    // Dependency Property
    public static readonly DependencyProperty TestProperty = 
         DependencyProperty.Register( "Test", typeof(string),
         typeof(UserControl1 ));
     
    // .NET Property wrapper
    public string Test
    {
        get { return GetValue(TestProperty ).; }
        set { SetValue(TestProperty , value); }
    }
