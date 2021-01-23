    public void MyMethod(Func<string[], string> delegateMethod, params string[] listOfString)
    {
        if (delegateMethod != null)
        {
            string value = delegateMethod(listOfStrings);
        }
    }
