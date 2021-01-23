    public static readonly DependencyProperty PrePendProperty = DependencyProperty.Register("PrePend", typeof(string), typeof(MyTextBox), new PropertyMetadata(String.Empty, OnPrePendPropertyChanged ));
      
    private static void OnPrePendPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
    {
       var ctl = sender as MyTextBox ;
       ctl.OnPrePendChanged();
    }
    protected virtual void OnPrePendChanged()
    {
       // do your magic here
    }
