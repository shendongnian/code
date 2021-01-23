    int totals[] = new totals[4];
    foreach (var sVal in File.ReadLines(txtCheminAccess.Text))
    {
        if (sVal.Length > 0)
        {
            mots = sVal.Split(',');
            for (int i = 1; i < 5 && i < sVal.Length; ++i)
            {
                int val;
                if (int.TryParse(sVal[i], out val))
                {
                    totals[i-1] += val;
                }
            }
        }
    }
