	private Font font = new Font("Arial", 13f, FontStyle.Regular, GraphicsUnit.Pixel, 0, false);
	[XmlIgnore()]
	public Font Font {
		get { return font; }
		set { font = value; }
	}
	[Browsable(false)]
	public string FontSerialize {
		get { return TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(font); }
		set { font = TypeDescriptor.GetConverter(typeof(Font)).ConvertFromInvariantString(value) as Font; }
	}
