	[Localizable(true), RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue('0')]
	public new char PromptChar
	{
		get { return base.PromptChar; }
		set { base.PromptChar = value; }
	}
	[MergableProperty(false), Localizable(true), RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.MaskPropertyEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("\\0xAAAA")]
	public new string Mask
	{
		get { return base.Mask; }
		set { base.Mask = value; }
	}
