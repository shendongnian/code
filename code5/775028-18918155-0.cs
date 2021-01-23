    int target = 4;
    for (int i = 0; i < list.Count; ++i)
    {
        if (list[i].UniqueID == target)
        {
            list.RemoveAt(i);
            break;
        }
    }
