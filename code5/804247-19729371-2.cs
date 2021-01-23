    public static readonly DependencyProperty EnableWatchProperty = DependencyProperty.RegisterAttached(
			"EnableWatch",
			typeof( bool ),
			typeof( ToolTipFix ),
			new PropertyMetadata( default( bool ), OnEnableWatchPropertyChanged ) );
		private static void OnEnableWatchPropertyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
		{
			var toolTip = d as ToolTip;
			if( toolTip == null ) return;
			var newValue = (bool) e.NewValue;
			if( newValue )
			{
				toolTip.Opened += OnTooltipOpened;
				toolTip.Closed += OnTooltipClosed;
			}
			else
			{
				toolTip.Opened -= OnTooltipOpened;
				toolTip.Closed -= OnTooltipClosed;
			}
		}
