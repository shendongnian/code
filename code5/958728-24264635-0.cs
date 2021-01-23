    FieldInfo parentProperty = typeof(XElementExtended).GetField("parent",
                BindingFlags.NonPublic | BindingFlags.Instance);
    public void Add(XElementExtended element)
    {
    	var el = new XElementExtended(element);
    	parentProperty.SetValue(el, null);
    	base.Add(el);
    }
