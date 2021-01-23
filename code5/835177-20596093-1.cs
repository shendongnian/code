    public void LoadData()
    {
       var orderedFullName = (from Member b in MemberDB.Members orderby b.FullName select b);
       Data.Clear();
       foreach (Member m in orderedFullName)
           Data.Add(m);
    }
