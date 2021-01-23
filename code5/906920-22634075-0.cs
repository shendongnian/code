    s => 
    {
        if (s == null)
        {
            return false;
        }
        if (!File.Exist(s))
        {
            throw new FileNotFoundException(s);
        }
        return true;
    }
