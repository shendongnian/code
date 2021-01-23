    public List<string> getOfficerNames()
    {
        List<string> names = new List<string>;
        foreach (Officer o in officerList)
                {
                    names.Add(o.Title + o.ForeName + o.SurName);
                }
        return names;
    }
