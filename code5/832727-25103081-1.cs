    public string Property(EdmProperty edmProperty)
    {
        string comments = Comments(edmProperty);
        return string.Format(
            CultureInfo.InvariantCulture,
            @"{5}{0} {1} {2} {{ {3}get; {4}set; }}",
            Accessibility.ForProperty(edmProperty),
            _typeMapper.GetTypeName(edmProperty.TypeUsage),
            _code.Escape(edmProperty),
            _code.SpaceAfter(Accessibility.ForGetter(edmProperty)),
            _code.SpaceAfter(Accessibility.ForSetter(edmProperty)),
            comments);
    }
    public string NavigationProperty(NavigationProperty navProp)
    {
        string comments = Comments(navProp);
        var endType = _typeMapper.GetTypeName(navProp.ToEndMember.GetEntityType());
        return string.Format(
            CultureInfo.InvariantCulture,
            "{5}{0} {1} {2} {{ {3}get; {4}set; }}",
            AccessibilityAndVirtual(Accessibility.ForNavigationProperty(navProp)),
            navProp.ToEndMember.RelationshipMultiplicity == RelationshipMultiplicity.Many ? ("ICollection<" + endType + ">") : endType,
            _code.Escape(navProp),
            _code.SpaceAfter(Accessibility.ForGetter(navProp)),
            _code.SpaceAfter(Accessibility.ForSetter(navProp)),
            comments);
    }
