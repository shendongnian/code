    // The last element can't be a duplicate of anything,
    // so we don't need to check it
    for (int i = 0; i < list.Count - 1; i++)
    {
        // Go backwards from the end, looking for duplicates of list[i]
        for (int j = list.Count - 1; j > i; j--)
        {
            if (list[j] == list[i])
            {
                list.RemoveAt(j);
            }
        }
    }
