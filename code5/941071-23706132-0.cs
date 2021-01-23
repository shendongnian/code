    ViewModelBinder.BindActions =
	(namedElements, viewModelType) =>
	{
		var methods = viewModelType.GetMethods();
		var unmatchedElements = namedElements.ToList();
		foreach (var method in methods)
		{
			var foundControl = unmatchedElements.FindName(method.Name);
			if (foundControl == null)
			{
				Log.Info("Action Convention Not Applied: No actionable element for {0}.", method.Name);
				continue;
			}
			unmatchedElements.Remove(foundControl);
			var message = method.Name;
			var parameters = method.GetParameters();
			if (parameters.Length > 0)
			{
				message += "(";
				foreach (var parameter in parameters)
				{
					var paramName = parameter.Name;
					var specialValue = "$" + paramName.ToLower();
					if (MessageBinder.SpecialValues.ContainsKey(specialValue))
						paramName = specialValue;
					message += paramName + ",";
				}
				message = message.Remove(message.Length - 1, 1);
				message += ")";
			}
			Log.Info("Action Convention Applied: Action {0} on element {1}.", method.Name, message);
			Message.SetAttach(foundControl, message);
		}
		return unmatchedElements;
	};
