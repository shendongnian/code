    class Program
    {
        static void Main(string[] args)
        {
            double[] arr1= { 1, 1, 1, 1 };
            double[] arr2= { 2, 2, 3, 2, 2 };
            double[] res=arr1.Take(2).Concat(arr2.Skip(1).Take(3)).ToArray();
            // res = {1, 1, 2, 3, 2}
        }
    }
