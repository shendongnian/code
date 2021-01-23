    foreach (int[] xs in xss)
    {
        int i = Array.IndexOf(xs, 6);
        if (i >= 0)
        {
            int j = Array.IndexOf(xs, 1, i);
            if (i + 1 == j)
            {
                // list contains a 6, followed by a 1
            }
        }
    }
