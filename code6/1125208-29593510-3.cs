    class Program
    {
      static void Main(string[] args)
      {
         ...
         Calculation calc = new Calculation(new MyContext());
         //use result, perhaps many times
         /*something with calc.Result; */
         
         ...
         //Maybe this method is invoked
         calc.Result.DoMethod();
         
         //context will not go away until Calculation does
      }
    }
    class Calculation
    {
        private MyContext context = null;
        private Xy result = null;
        
        public Calculation(MyContext context)
        {
            this.context = context;
        }
        
        public Xy Result {
            get {
                if (result == null) {
                    result = Calculate();
                }
                return result;
            }
        }
      
        private Xy Calculate();
        {
          Xy result;
          xyList = context.Xys.ToList();
          ...
          result = xyList[calculatedIndex];
          return result;
        }
    }
