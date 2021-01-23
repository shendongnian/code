    public void AreEqual(object value1, object value2, string message = null)
    {
        object value2Converted = Convert.ChangeType(value2, value1.GetType());
        if (value1.Equals(value2Converted))
        {
            AssertHandler.OnAssertSucceeded();
        }
        else
        {
            AssertHandler.OnAssertFailed("AreEqual", message);
        }
    }
