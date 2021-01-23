    if (rowCount[i] >= 10)
    {
        for (int j = 0; j < blocks.Count; j++)
        {
            if (blocks[j].Row == i)
            {
                blocks.RemoveAt(j);
                rowCount[i]--;
                j--;
            }
        }
        foreach (Block b in blocks)
        {
            if (b.Row < i)
            {
                b.Row++;
                rowCount[b.Row]++;
            }
        }
    }
