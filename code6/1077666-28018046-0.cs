	public enum TestEnum
	{
		//You can pass what ever string value you want
		[StringValue("From Attribute")]
		FromAttribute = 1,
		//If localizing, you can use resource files
		//First param is Key in resource file, second is namespace for Resources.
		[StringValue("Test", "EnumExtensions.Tests.Resources")]
		FromResource = 2,
		//or don't mention anything and it will use built-in ToString
		BuiltInToString = 3
	}
	[Test ()]
	public void GetValueFromAttribute ()
	{
		var testEnum = TestEnum.FromAttribute;
		Assert.AreEqual ("From Attribute", testEnum.GetStringValue ());
	}
	[Test ()]
	public void GetValueFromResourceFile ()
	{
		var testEnum = TestEnum.FromResource;
		Assert.AreEqual ("From Resource File", testEnum.GetStringValue ());
	}
