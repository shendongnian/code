    class Program
    {
      static void Main(string[] args)
      {
         ...
         Calculation calc = new Calculation();
         ...
         //Maybe this method is invoked
         calc.GetResult().DoMethod();
      }
    }
    
    class Calculation
    {      
        public Xy GetResult();
        {
          Xy result;
          using (var context = new MyContext())
          {
             xyList = context.Xys.ToList();
             ...
             result = xyList[calculatedIndex];
          }
          return result;
        }
    }
