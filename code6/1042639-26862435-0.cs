    public void getOfficerNames(List<string> names)
    {
        foreach (Officer o in officerList)
        {
            names.Add(o.Title + o.ForeName + o.SurName);
        }
    }
