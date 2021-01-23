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
        object[] arguments = new object[] { myDs };
        // Act:
        object val = method.Invoke(abstractClassFake, new[] { myDs });
        // Assert:
        // TODO: Your assertion here
    }
