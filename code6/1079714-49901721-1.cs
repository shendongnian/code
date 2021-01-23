	public XmlVariantFactory()
	{
		_xmlRoots = AppDomain.CurrentDomain
							 .GetAssemblies()
							 .SelectMany(a => a
											  .GetTypes()
											  .Select(t => new {t, t.GetCustomAttribute<XmlRootAttribute>()?.ElementName})
											  .Where(x => !string.IsNullOrEmpty(x.ElementName)))
							 .ToDictionary(x => x.ElementName, x => x.t);
	}
