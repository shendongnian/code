     public partial class YOUCLASS: UserControl
        {
            public YOUCLASS()
            {
                InitializeComponent();
    
               
            }
     public static readonly DependencyProperty IsVisibleEarnPointsProperty =
                DependencyProperty.Register("IsVisibleEarnPoints", typeof(bool), typeof(YOURCLASS), new UIPropertyMetadata((bool)false, OnStateChange));
    
            public bool IsVisibleEarnPoints
            {
                get
                {
                    return (bool)GetValue(IsVisibleEarnPointsProperty );
                }
                set
                {
                    SetValue(IsVisibleEarnPointsProperty , value);
                }
            }
    
            private static void OnStateChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue is bool)
                {
                    var source = (YOURCLASS)d;
                    source.SetState((bool)e.NewValue);
                }
            }
    
            public void SetState(bool isDisabled)
            {   
    
    if(isDisabled)
    {
    imgecoin.Visibility=Visibility.Visible;
    //same for other control
    }
    else
    {
    // Do whatever you want.
    }
    
                
            
         
        }`
