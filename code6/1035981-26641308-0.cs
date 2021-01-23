    // Original input to transform.
	string input = @"employee1@2 r&a*d.m32@@company98 ';99..com";
	// Regular expression to find and extract "Username" and "Domain" groups, if any.
	var matchGroups = Regex.Match(input, @"employee(?<UsernameGroup>(.*))@company(?<DomainGroup>(.*)).com");
	string validInput = input;
	// Get the username group from the list of matches.
	var usernameGroup = matchGroups.Groups["UsernameGroup"];
	if (!string.IsNullOrEmpty(usernameGroup.Value))
	{
		// Replace non-alphanumeric values with empty string.
		string validUsername = Regex.Replace(usernameGroup.Value, "[^a-zA-Z0-9]", string.Empty);
		// Replace the the invalid instance with the valid one.
		validInput = validInput.Replace(usernameGroup.Value, validUsername);
	}
	// Get the domain group from the list of matches.
	var domainGroup = matchGroups.Groups["DomainGroup"];
	if (!string.IsNullOrEmpty(domainGroup.Value))
	{
		// Replace non-alphanumeric values with empty string.
		string validDomain = Regex.Replace(domainGroup.Value, "[^a-zA-Z0-9]", string.Empty);
		// Replace the the invalid instance with the valid one.
		validInput = validInput.Replace(domainGroup.Value, validDomain);
	}
	Console.WriteLine(validInput);
