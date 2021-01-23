    string[] assets, allassets = null;
    int[] list1, list2, removed_list, added_list = null;
    assets = a.Split(',');
    list1 = Array.ConvertAll(assets, x => int.Parse(x))
    allassets = b.Split(',');
    list2 = Array.ConvertAll(allassets, x => int.Parse(x));
    removed_list = list2.Where(x => !list1.Contains(x)).ToArray(); // which gives =>a
    added_list = list1.Where(x => !list2.Contains(x)).ToArray(); // which gives =>b
