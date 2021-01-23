    private static int[][] getArrayForMyTestMethod(string key)
    {
        // logic to get from key to int[][]
    }
    [TestCase(5, 1, "dataset1")]
    public void MyTestMethod(int a, int b, string rKey)
    {
        int[][] r = getArrayForMyTestMethod(rKey);
        // elided
    }
