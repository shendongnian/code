    static void Main(string[] args)
    {
        object[][] x = weirdReturn();
        for (int i = 0; i < x.Length; i++)
        {
            for (int j = 0; j < x[i].Length; j++)
            {
                Console.Write("{0} ", x[i][j]);
            }
            Console.WriteLine("");
        }
    }
    static object[][] weirdReturn()
    {
        DateTime d = new DateTime();
        d = DateTime.Now;
        object[] a2 = { 'X', 1.79, d, 100 };
        object[] a1 = { 0, 'a', "objectX" };
        object[][] retVal = new object[2][];
        retVal[0] = a1;
        retVal[1] = a2;
        return retVal;
    }
