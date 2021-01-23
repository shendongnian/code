        Public Property MyVisibility As Windows.Visibility
        Get
            Return GetValue(MyVisibilityProperty)
        End Get
        Set(ByVal value As Windows.Visibility)
            SetValue(MyVisibilityProperty, value)
        End Set
    End Property
    Public Shared ReadOnly MyVisibilityProperty As DependencyProperty = _
                           DependencyProperty.Register("MyVisibility", _
                           GetType(Windows.Visibility), GetType(MyWindow), _
                           New PropertyMetadata(Nothing))
