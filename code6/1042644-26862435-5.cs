    public void GetOfficerNames(out List<string> names)
    {
        names = new List<string>();
        foreach (Officer o in officerList)
        {
            names.Add(o.Title + o.ForeName + o.SurName);
        }
    }
