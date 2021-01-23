    public static class ToolTipSwitch
	{
		private static bool s_isToolTipActivated = true;
		public static bool IsToolTipActivated
		{
			get { return s_isToolTipActivated; }
			set
			{
				if (s_isToolTipActivated != value)
				{
					s_isToolTipActivated = value;
					RaiseIsToolTipActivatedChanged();
				}
			}
		}
		private static void RaiseIsToolTipActivatedChanged()
		{
			var handlers = IsToolTipActivatedChanged;
			if (handlers != null) handlers();
		}
		public static event Action IsToolTipActivatedChanged;
	}
    
    public class SwitchOffConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ToolTipSwitch.IsToolTipActivated ? value : null;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
    public class SwitchOffUiTextResources : INotifyPropertyChanged
	{
		public SwitchOffUiTextResources()
		{
			ToolTipSwitch.IsToolTipActivatedChanged += OnIsToolTipActivatedChanged;
		}
		private void OnIsToolTipActivatedChanged()
		{
			RaisePropertyChanged( "LocalizedText" );
		}
		private UiTextResources m_localizedText = new UiTextResources();
		public UiTextResources LocalizedText
		{
			get { return ToolTipSwitch.IsToolTipActivated ? m_localizedStrings : null; }
		}
		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
