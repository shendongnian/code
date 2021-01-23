    public static readonly DependencyProperty OpenDropDownAutomaticallyProperty = 
                               DependencyProperty.RegisterAttached("OpenDropDownAutomatically",
                                 typeof(bool),
                                 typeof(ComboBox_ForceDropDown),
                                 new UIPropertyMetadata(false, onOpenDropDownAutomatically_Changed)
                                );
