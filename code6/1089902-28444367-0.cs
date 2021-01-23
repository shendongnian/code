    public class MyDouble
    {
         public double Value {get; set;}
         
         public static double operator +(MyDouble x, MyDouble y){
            return Math.Round(x.Value + y.Value)
         }
    }
