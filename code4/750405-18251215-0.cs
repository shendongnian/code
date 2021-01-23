    // The IsNotNull overload that takes only "value" calls this one internally
    public static void IsNotNull(object value, string message, params object[] parameters)
    {
      if (value != null)
        return;
      Assert.HandleFail("Assert.IsNotNull", message, parameters);
    }
    // The AreNotEqual that takes only "notExpected" and "actual" calls this one internally
    public static void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
    {
      if (!object.Equals((object) notExpected, (object) actual))
        return;
      Assert.HandleFail("Assert.AreNotEqual", (string) FrameworkMessages.AreNotEqualFailMsg(message == null ? (object) string.Empty : (object) Assert.ReplaceNulls((object) message), (object) Assert.ReplaceNulls((object) notExpected), (object) Assert.ReplaceNulls((object) actual)), parameters);
    }
