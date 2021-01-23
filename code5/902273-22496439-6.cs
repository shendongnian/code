    Assert.AreEqual<object>(expected, actual, message, parameters);
    public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
    {
      message = Assert.CreateCompleteMessage(message, parameters);
      if (object.Equals((object) expected, (object) actual))
        return;
      Assert.HandleFailure ...
    }
