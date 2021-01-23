    public static readonly DependencyProperty IsConnectedProperty =
        DependencyProperty.Register( "IsConnected", typeof( bool ), typeof( MyViewModel ), new PropertyMetaData( false ) );
    public bool IsConnected {
        get { return (bool) GetValue( IsConnectedProperty ); }
        set { SetValue( IsConnectedProperty, value ); }
    }
