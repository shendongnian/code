    public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
    {
    	message = Assert.CreateCompleteMessage(message, parameters);
    	if (!object.Equals(expected, actual))
    	{
    		string message2;
    		if (actual != null && expected != null && !actual.GetType().Equals(expected.GetType()))
    		{
    			message2 = FrameworkMessages.AreEqualDifferentTypesFailMsg((message == null) ? string.Empty : Assert.ReplaceNulls(message), Assert.ReplaceNulls(expected), expected.GetType().FullName, Assert.ReplaceNulls(actual), actual.GetType().FullName);
    		}
    		else
    		{
    			message2 = FrameworkMessages.AreEqualFailMsg((message == null) ? string.Empty : Assert.ReplaceNulls(message), Assert.ReplaceNulls(expected), Assert.ReplaceNulls(actual));
    		}
    		Assert.HandleFailure("Assert.AreEqual", message2);
    	}
    }
