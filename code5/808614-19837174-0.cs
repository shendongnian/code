    public static void Assert(Func<bool> cond, string message = "")
    {
        if(cond())
        {
            Assert.Ignore(message);
        }
    }
