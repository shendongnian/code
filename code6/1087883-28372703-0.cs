    public List<int> PaceCalc(List<int> Dlist, List<int> Slist)
    {
        List<int> Plist = new List<int>();
        for (int i = 0; i < Dlist.Count; i++)
        {
            int PaceInt = Dlist[i] / Slist[i];
            Plist.Add(PaceInt);
        }
        return Plist;
    }
