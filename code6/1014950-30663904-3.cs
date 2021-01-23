    public bool IsMaximized
    {
        get { return (bool)GetValue(IsMaximizedProperty); }
        set
        {
            SetValue(IsMaximizedProperty, value);
            UpdatePositionAndSizeOfPanes();
        }
    }
