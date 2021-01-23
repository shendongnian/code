    static int[] mnozenie(int[] tab, int mnoznik)
    {
        if (tab.Length > 0)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] *= mnoznik;
            }
            return tab;
        }
        return null;
    }
