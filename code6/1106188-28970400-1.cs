    object[] args = new object[] { stringSource, null };
    var tryParseReturn = target.InvokeStatic("TryParse", args);
    ...
    // args[1] will have the value assigned to the out parameter
    Assert.AreEqual(expectedOut, args[1]);
