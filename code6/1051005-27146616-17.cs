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
				//FIX_20141127
                //MaxLengthProperty_Set.Invoke(this, new object[] { Mask.Replace("\\", string.Empty).Length });
				SetMaxLength(Mask.Replace("\\", string.Empty).Length);
			}
		}
	}
	//FIX_20141127
    private void SetMaxLength(int value)
	{
		if (IsHandleCreated)
		{
			MaxLengthProperty_Set.Invoke(this, new object[] { value});
			MaxLengthField.SetValue(this, value);
		}
	}
	private static readonly PropertyInfo MaxLengthProperty = typeof(TextBoxBase).GetProperty("MaxLength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
	private static readonly MethodInfo MaxLengthProperty_Set = MaxLengthProperty.GetSetMethod();
    //FIX_20141127
    private static readonly FieldInfo MaxLengthField = typeof(TextBoxBase).GetField("maxLength", BindingFlags.Instance | BindingFlags.NonPublic);
