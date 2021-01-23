    static int[] mnozenie(int[] tab, int mnoznik)
    {
        if (tab.Length > 0)
        {
            foreach (int item in tab)
            {
                item = item*mnoznik;
            }
            return tab;
        }
        return null;
    }
