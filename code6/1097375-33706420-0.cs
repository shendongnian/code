    public static readonly DependencyProperty BindingTextValueProperty = DependencyProperty.Register(
                                     "BindingTextValue",
                                     typeof(string),
                                     typeof(TextBoxS),
                                     new PropertyMetadata(default(string), PropertyChangedCallback));
									 
	private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args) {
		
		//This method adds some custom logic into RichTextBlock, pointed correctly
		var textBoxS = dependencyObject as TextBoxS;
		
		textBoxS.SetupSpotterBox((string) args.NewValue);
	}
									 
									 
    public string BindingTextValue
    {
        get { return GetValue(BindingTextValueProperty) as string; }
        set { SetValue(BindingTextValueProperty, value); }
    }
