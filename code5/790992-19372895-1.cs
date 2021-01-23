    private static void Main()
    {
        int[] a = A(1, 2, 3);
        double[] b = A(1.2, 3.4, 1);
    }
    private static T[] A<T>(params T[] array)
    {
        return array;
    }
