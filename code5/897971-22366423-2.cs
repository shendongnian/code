    MethodInfo startMethod = type.GetMethod("Start", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static, null, new Type[] { }, null);
    if (startMethod != null)
    {
      startMethod.Invoke(null, new object[] { });
    }
