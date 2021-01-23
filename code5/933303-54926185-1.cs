	var parameters = new Dictionary<string, object>
	{
		{ "@username", username.AsDbValue() },
		{ "@password", password.AsDbValue() },
		{ "@birthDate", birthDate.AsDbValue() },
	};
