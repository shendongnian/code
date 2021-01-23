	[XmlIgnore()]
	public Font Font {
		get { return font; }
		set { font = value; }
	}
	[Browsable(false)]
	public string FontSerialize {
		get { return new FontConverter().ConvertToInvariantString(font); }
		set { font = new FontConverter().ConvertFromInvariantString(value) as Font; }
	}
