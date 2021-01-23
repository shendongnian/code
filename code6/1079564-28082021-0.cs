    foreach (Chatter e in c)
    {
        var temp_lc = lc.Where(x => x.Name == e.Name).SingleOrDefault();
        if (temp_lc == null)
        {
            lc.Add(e);
        }
        else
        {
            temp_lc.Msgs = temp_lc.Msgs.Concat(e.Msgs).ToList();
        }
    }
