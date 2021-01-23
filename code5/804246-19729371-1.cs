    public static readonly DependencyProperty IsOpenProperty = DependencyProperty.RegisterAttached(
			"IsOpen",
			typeof( bool ),
			typeof( ToolTipFix ),
			new PropertyMetadata( default( bool ) ) );
