    public void SomeMethod(string s)
    {
        switch (s)
        {
            case "stringA":
            case "stringB":
                break;
            default:
                throw new ArgumentException("Value invalid.", "s");
        }
        // Do something.
    }
