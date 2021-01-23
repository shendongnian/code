    if (rowCount[i] >= 10)
    {
        for (int j = blocks.Count - 1; j >= 0; j--)
        {
            if (blocks[j].Row == i)
            {
                blocks.RemoveAt(j);
                rowCount[i]--;
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
