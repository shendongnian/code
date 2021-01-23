    private static void OnControlSizePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
    {
        CustomControl customControl = source as CustomControl;
        Size controlSize = ControlSizeConverter.ConvertToSize(ControlSize);
        customControl.Width = controlSize.Width;
        customControl.Height = controlSize.Height;
    }
