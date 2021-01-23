    foreach (var grp in results)
    {
        string groupCode = grp.itemcode;
        foreach (var subGrp in grp.subItemGroups)
        {
            string subItemGroup = subGrp.Key;
            Console.WriteLine("groupCode:{0} subItemGroup:{1} codes:{2}"
                , groupCode
                , subItemGroup
                , String.Join(",", subGrp.Select(si => si.subItemCode)));
        }
    }
