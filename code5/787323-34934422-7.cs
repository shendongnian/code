	[XmlIgnore()]
	public Font Font {
		get { return font; }
		set { font = value; }
	}
	[Browsable(false)]
	public string FontSerialize {
		get { return TypeDescriptor.GetConverter(font.GetType()).ConvertToInvariantString(font); }
		set { font = TypeDescriptor.GetConverter(font.GetType()).ConvertFromInvariantString(value) as Font; }
	}
