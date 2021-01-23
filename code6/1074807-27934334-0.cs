     public string Property(EdmProperty edmProperty)
    {
        string type = _typeMapper.GetTypeName(edmProperty.TypeUsage);
		string propertyName = _code.Escape(edmProperty);
		
		if(type == "string"){
		return string.Format(
            CultureInfo.InvariantCulture,
			"private {1} _{6}; {5} \t{0} {1} {2} {{ {5}\t\t{3}get{{return _{6} == null ? null : _{6}.Trim();}} {5}\t\t{4}set{{ _{6} = value;}} }}",
            Accessibility.ForProperty(edmProperty),
            type,
            propertyName,
            _code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
            _code.SpaceAfter(Accessibility.ForSetter(edmProperty)),
			Environment.NewLine,
			propertyName.ToLower()
			);
		}else{
		return string.Format(
            CultureInfo.InvariantCulture,
            "{0} {1} {2} {{ {3}get; {4}set; }}",
            Accessibility.ForProperty(edmProperty),
            _typeMapper.GetTypeName(edmProperty.TypeUsage),
            _code.Escape(edmProperty),
            _code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
            _code.SpaceAfter(Accessibility.ForSetter(edmProperty)));
			}
    }
