	class AbstractClassFake : AbstractClass { }
    [Test]
    public void Test()
    {
        // Arrange:
        var abstractClassFake = (AbstractClassFake)FormatterServices
			.GetUninitializedObject(typeof(AbstractClassFake));
        MethodInfo method = abstractClassFake.GetType()
        	.GetMethod("ProtectedMethod",
        		BindingFlags.Instance | BindingFlags.NonPublic);
        int inputArg = 0;
        // Act:
        object val = method.Invoke(abstractClassFake, new[] { (object)inputArg });
        // Assert:
        Assert.That(val, Is.EqualTo(4));
    }
