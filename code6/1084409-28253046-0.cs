    public static readonly DependencyProperty InputValueProperty = DependencyProperty.Register (
        "InputValue",
        typeof(int),
        typeof(ConverterDisplay),
        new PropertyMetadata (DEFAULT_INPUT_VALUE, InputValueChangedCallback));
		
		
	private static void InputValueChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
	{
		var userControl = dependencyObject as ConverterDisplay;
		if (userControl != null)
			userControl.UpdateDisplay();
	}
