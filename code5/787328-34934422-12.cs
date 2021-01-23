	[XmlIgnore()]
	public Font Font {
		get { return font; }
		set { font = value; }
	}
	[Browsable(false)]
	public string FontSerialize {
		get { return FontSerializationHelper.ToString(font); }
		set { font = FontSerializationHelper.FromString(value); }
	}
