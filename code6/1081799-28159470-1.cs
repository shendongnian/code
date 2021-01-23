    public static void Expect<TExpectedException>(
        System.Action action,
        System.Action<TExpectedException> assertion) where TExpectedException : Exception
    {
        if (action == null) { throw new ArgumentNullException("action"); }
        try
        {
            action.Invoke();
            Assert.Fail(string.Format("{0} expected to be thrown", typeof(TExpectedException).Name));
        }
        catch (TExpectedException e)
        {
            assertion.Invoke(e);
        }
    }
