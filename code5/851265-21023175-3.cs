    public IEnumerable<string> SomeMethod(int NumberOfChars) 
    {
        if (NumberOfChars == 0)
        {
            yield return string.Empty;
        }
        else 
        {
            for (var i = 'a'; i <= 'z'; i++)
            {
                foreach (var s in SomeMethod(NumberOfChars - 1)) 
                {
                    yield return i + s;
                }
            }
        }
    }
