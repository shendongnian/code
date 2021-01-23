    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        IProvideValueTarget target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
        if (target != null && target.TargetObject is ComboBox)
        {
            ((ComboBox)target.TargetObject).SelectedValuePath = "Value";
        }
        var enumValues = Enum.GetValues(EnumType);
        return (
           from object enumValue in enumValues
           select new EnumMember
           {
              Value = enumValue,
              Display = GetDescription(enumValue)
           }).ToArray();
    }
