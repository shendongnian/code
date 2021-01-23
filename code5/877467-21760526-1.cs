    private void Control_VisibleChanged(object sender, 
                                            DependencyPropertyChangedEventArgs e)
    {
        if ((Visibility)e.NewValue == Visibility.Visible)
        {
           // Visible code here
        }
        else
        { 
           // Collapse code here
        }
     }
