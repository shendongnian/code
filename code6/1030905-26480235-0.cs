    protected void SplitName(string Name, out string FirstName, out string MiddleName)
    {
        char[] delimiterChars = { ',' };
        string[] name = acEmployee.Text.Split(delimiterChars);
        string Lastname = name[0];
        Middlename = name[1].Substring(Math.Max(0, name[1].Length - 1));
        Firstname = name[1] = name[1].Remove(name[1].Length - 1);
    }
