    var startingSchemas = new [] { "100**101", "110*101*", "1111*000" };
    
    startingSchemas.Any(x => IsSubsetOf(x, "11****11")); // false
    startingSchemas.Any(x => IsSubsetOf(x, "11011010")); // true
    public bool IsSubsetOf(string main, string sub)
    {
        for (var i = 0; i < main.Length; i++)
        {
            if (main[i] == '*') continue;    // main is '*', so anything is ok
            if (main[i] == sub[i]) continue; // equal is ok, both 1/0/*
            return false; // if not equal, sub[i] could be *, or the opposite of main[i]
        }
        return true;
    }
