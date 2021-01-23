    public void AreEqual(object value1, object value2, string message = null)
    {
        bool convertedOk = true;
        object value2Converted;
        try
        {
             value2Converted = Convert.ChangeType(value2, value1.GetType());
        }
        catch 
        {
             convertedOk = false;
        }
        if (convertedOk && value1.Equals(value2Converted))
        {
            AssertHandler.OnAssertSucceeded();
        }
        else
        {
            AssertHandler.OnAssertFailed("AreEqual", message);
        }
    }
