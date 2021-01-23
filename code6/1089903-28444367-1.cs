    public struct MyDouble
    {
         public double Value {get; set;}
         public MyDouble(double initValue)
         {
             Value = initValue;
         }         
         public static double operator +(MyDouble x, MyDouble y){
            return Math.Round(x.Value + y.Value)
         }
    }
