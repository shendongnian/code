    var result = AppDomain.CurrentDomain.GetAssemblies()
	.Where(a => !a.IsDynamic)
	.SelectMany(
                // possible full names is a list which tries replacing each . in the name with a +
                // starting from the end
		a => possibleFullNames.Select(t => new { t.@namespace, type = a.GetType(t.fullName) })
	)
	.Where(t => t.type != null);
