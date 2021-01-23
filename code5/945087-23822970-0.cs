    bool add_space = false;
    PIDages.Sort();
    lollist.WriteLine();
    foreach (int a in PIDages)
    {
        if (add_space)
            lollist.Write("  ");
        else
            add_space = true;
        lollist.Write(a);
    }
    PIDages.Clear();
