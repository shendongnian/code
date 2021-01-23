    System.Diagnostics.Fakes.ShimProcess.StartString = s =>
    {
        Console.WriteLine(s);
        return new StubProcess();
    };
    // A call to your method under test that exectues Process.Start rather than calling it directly
    var process = Process.Start("SomeString");
    Assert.IsTrue(process is StubProcess);
