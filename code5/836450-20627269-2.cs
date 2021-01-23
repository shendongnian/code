    bool found = false;
    for (int bIndex = 0; !found && bIndex < b.Length; bIndex++)
    {
        int k = b[bIndex];
        if (hm.Contains(k))
        {
            for (int cIndex = 0; !found && cIndex < c.Length; cIndex++)
            {
                int j = c[cIndex];
                if (j == k && hm.Contains(j))
                {
                    Console.WriteLine(j);
                    found = true;
                }
            }
        }
    }
