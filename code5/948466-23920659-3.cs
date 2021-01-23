    class Program
    {
        static void Main(string[] args)
        {
            Array<double> arr1= new double[] { 1, 1, 1, 1 };
            Array<double> arr2= new double[] { 2, 2, 3, 2, 2 };
            Array<double> res=arr1[Index.Span(0, 2)]&arr2[Index.Span(1, 3)];
            // res = {1, 1, 2, 3, 2}
            Array<double> res2=2*res+1;
            // res2 = {3, 3, 5, 7, 5}
            Array<double> res3=res2.Apply(Math.Sqrt);
            // res3 = {√3, √3, √5, √7, √5}
        }
    }
