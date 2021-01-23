    public static class MathExtensions
    {
       public static double StandardDeviation<T>(this List<T> list, Func<T, Double> selector) where T : class
       {
          var m = 0.0;
          var s = 0.0;
          var k = 1;
          foreach (var value in list.Select(selector))
          {
             var tmpM = m;
             m += (value - tmpM) / k;
             s += (value - tmpM) * (value - m);
             k++;
          }
          return Math.Sqrt(s / (k - 2));
       }
    }
