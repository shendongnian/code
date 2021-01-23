    int[] selected = new int[quantity];
    int num = 0;  // number of True items seen
    Random rnd = new Random();
    for (int i = 0; i < items.Length; ++i)
    {
        if (items[i])
        {
            ++num;
            if (num <= quantity)
            {
                selected[num-1] = i;
            }
            else
            {
                double prob = (double)quantity/num;
                if (rnd.Next() > prob)
                {
                    int ix = rnd.Next(quantity);
                    selected[ix] = i;
                }
            }
        }
    }
