    [TestCase("")]
    public void TestParameterAttribute([NotRequired]string theString)
    {
		var method = MethodInfo.GetCurrentMethod();
		var parameter = method.GetParameters()[0];
        var result = false;
        foreach (var attribute in parameter.GetCustomAttributes(true))
        {
            if (attribute.GetType() == (typeof(NotRequiredAttribute)))
            {
                result = true;
            }
        }
        Assert.That(result, Is.True);
    }
