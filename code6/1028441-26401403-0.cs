    private static void OnDisplayedTagPropertyChanged(DependencyObject source, 
        DependencyPropertyChangedEventArgs e)
    {
        MyUserControl ctrl = source as MyUserControl;
        if(ctrl == null) // should not happen
          return;
          
        Button b = ctrl.mainButton;
          
        Tag tag = (Tag)e.NewValue;
        mainButton.Content = tag.TagName;
    }
