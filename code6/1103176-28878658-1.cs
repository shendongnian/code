    for (int j = 0; j < od.Count; j++)
    {
        for (int i = 0; i < od.Count - 1; i++)
        {
            // insert your custom comparer here:
            if (od.ElementAt(i + 1).Item1 < od.ElementAt(i).Item1)
            {
                var temp0 = od.ElementAt(i);
                var temp1 = od.ElementAt(i + 1);
                od.RemoveAt(i);
                od.RemoveAt(i);
                od.Insert(i, temp1);
                od.Insert(i+1, temp0);
            }
        }
    }
