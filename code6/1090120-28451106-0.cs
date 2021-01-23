    private bool SomeFunction(string preDefined, string str)
    {
        foreach (char ch in str)
        {
            if (!preDefined.Contains(ch))
            {
                return false;
            }
        }
        return true;
    }
