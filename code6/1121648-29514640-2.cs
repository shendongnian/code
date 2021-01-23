	using System;
	using System.Runtime.Serialization;
	using WindowsMedia = System.Windows.Media;
	namespace Something.Something.DarkSide
	{
		[NonSerialized]
		private readonly WindowsMedia.BrushConverter _colorConverter = new WindowsMedia.BrushConverter();
    	[Serializable]
    	[DataContract]
    	public class ClassName: SerializeableBase<ClassName>
    	{
    		[DataMember(Name = "ColorString")]
    		private string _colorString;
    		public string ColorString
    		{
    			get { return _colorString; }
    			set
    			{
    				_colorString = value;
    				_color = (WindowsMedia.Brush)_colorConverter.ConvertFrom(value);
    				OnPropertyChanged();
    			}
    		}
    
            // Color
    		[NonSerialized]
    		private WindowsMedia.Brush _color = WindowsMedia.Brushes.Yellow;
    		public WindowsMedia.Brush Color
    		{
    			get { return _color; }
    			set
    			{
    				_color = value;
    				_colorString = _colorConverter.ConvertToString(value);
    				OnPropertyChanged();
    			}
    		}
            // This triggered when deserializing.
            // When deserializing we will have the _color property as null since
            // nothing is setting it. 
            // This ensures we initialize the _color when deserializing from the ColorString property.
            [OnDeserialized]
		    private void SetValuesOnDeserialized(StreamingContext context)
		    {
			    _colorConverter = new WindowsMedia.BrushConverter();
			    _color = (WindowsMedia.Brush)_colorConverter.ConvertFrom(ColorString);
		    }
    
    		public Annotation(string colorHexValue = null)
    		{
    			var colorBrush = (WindowsMedia.Brush)_colorConverter.ConvertFrom(colorHexValue);
    			Color = colorBrush ?? WindowsMedia.Brushes.Yellow;
    		}
    
    		public Annotation(WindowsMedia.Brush colorBrush = null)
    		{
    			Color = colorBrush ?? WindowsMedia.Brushes.Yellow;
    		}
        }
	}
