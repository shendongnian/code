    public string Represent(string s)
    {
        int i = 0;
        if (int.TryParse(s, out i))
        {
            return(i.ToString().PadLeft(6,'0'));
        }
    }
