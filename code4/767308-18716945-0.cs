    public string SplitName(string text)
    {
        string forename;
        string middlename;
        string surname;
        var name = text.Split(' ');
        if (name != null)
        {
            if (name.Length > 2)
            {
                forename = name[0];
                surname = name[name.Length - 1];
                middlename = string.Join(" ", name, 1, name.Length - 2);
                text = string.Format("{0} {1} {2}", forename, middlename, surname);
            }
        }
        else
        {
            text = "INVALID";
        }
        return text;
    }
