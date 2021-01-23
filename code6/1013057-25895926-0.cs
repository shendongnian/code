    public bool Property1
    {
        get { return ( bool ) GetValue( Property1Property ); }
        set { SetValue( Property1Property, value ); }
    }
    
    // Using a DependencyProperty as the backing store for Property1.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty Property1Property =
         DependencyProperty.Register( "Property1", typeof( bool ), typeof( XXXX ), new PropertyMetadata( false ) );
