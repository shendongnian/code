    public string Test()
    {
        int[] intx = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int j = intx.Length-1;
        for (int i = 0; i < 4; i++)
        {
            if ((intx[i] + intx[j - 1]) == 10)
            {
                 return (intx[i].ToString() + " and " + intx[j--].ToString());
            }
        }
        return "";
    } 
