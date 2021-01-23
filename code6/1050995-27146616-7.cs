	[MergableProperty(false), Localizable(true), RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.MaskPropertyEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("\\0xAAAA")]
	public new string Mask
	{
		get { return base.Mask; }
		set
		{
			if (base.Mask != value)
			{
				base.Mask = value;
				MaxLengthProperty_Set.Invoke(this, new object[] { Mask.Replace("\\", string.Empty).Length });
			}
		}
	}
	private static readonly PropertyInfo MaxLengthProperty = typeof(TextBoxBase).GetProperty("MaxLength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
	private static readonly MethodInfo MaxLengthProperty_Set = MaxLengthProperty.GetSetMethod();
