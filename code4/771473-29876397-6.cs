	// Object to work on
	var obj = new TextBox();
	// accessor using Expressions
	var acc1 = Factory.Accessor(() => obj.Enabled);
	// accessor using Lambdas
	var acc2 = Factory.Accessor() => obj.Enabled, v => obj.Enabled = v);
