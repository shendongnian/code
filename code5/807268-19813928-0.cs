	Predicate<string> isGuid = s =>
	{
		Guid g;
		return Guid.TryParse(s, out g);
	};
	var names = _container.Model.AllInstances.Where(x => x.PluginType == typeof (IPolicy))
										    .Where(x => !isGuid(x.Name))
										    .Select(x => x.Name)
										    ;
