    for (int i = 0; i < originalList.Length; i++)
    {
        if (originalList[i] == 0)
        {
            originalList.RemoveAt(i);
            i--;
        }
    }
