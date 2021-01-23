    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        // Only set the default value if no value is set.
        if (MyProperty == (int)MyPropertyProperty.DefaultMetadata.DefaultValue)
        {
            this.MyProperty = GetDefaultPropertyValue();
        }
    }
