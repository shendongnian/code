    public float random(int newitemid)
    {
        // Create a new array with a bigger length and give it the old arrays values
        float[][] b = new float[a.Length + 1][];
        for (int i = 0; i < a.Length; i++)
            b[i] = a[i];
        a = b;
        // Add random values to the last entry
        int userid = a.Length - 1;
        Random randomvalues = new Random();
        float randomnum;
        a[userid] = new float[100];
        for (int counter = 0; counter < 100; counter++)
        {
            randomnum = randomvalues.Next(0, 1);
            a[userid][counter] = randomnum;
        }
        return a;
    }
