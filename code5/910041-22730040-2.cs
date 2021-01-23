    // We're looking for duplicates *after* list[i], so we don't need to go as far
    // as i being the very last element: there aren't any elements after it to be
    // duplicates. (We could easily still just use list.Count, and the loop for j
    // would just have 0 iterations.)
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
