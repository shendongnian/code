    int count = x.Count;
    if (count > 0)
    {
        for (int i = 0; i < count; i++)
        {
            param.PersistentData.Append(new GH_String(x[i]));
        }
    }
