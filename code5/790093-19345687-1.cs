    foreach (List<E> list in listOfList)
    {
        foreach (E item in list)
        {
            List<List<E>> itemList;
            if (!dic.TryGetValue(item, out itemList))
            {
                dic[item] = itemList = new List<List<E>>();
            }
            itemList.Add(list);
        }
    }
