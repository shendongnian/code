     Public Shared ReadOnly MyVisibilityProperty As DependencyProperty = _
                           DependencyProperty.Register("MyVisibility", _
                           GetType(Windows.Visibility), GetType(MyWindow), _
                           New PropertyMetadata(Windows.Visibility.Hidden))
 
