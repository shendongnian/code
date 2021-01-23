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
         
      }
    }
    
    // POCO class
    public class XY
    {
      public virtual List<Xz> SomeObjects { get; set; } 
      public virtual void DoMethod()
      {
        foreach (var obj in SomeObjects)
        {
           ...
        }
      }
    }
    
    public class XYInterceptor : XY, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name == "DoMethod")
            {
                //get a new context so that we can have SomeObjects resolve properly
                using (var context = new MyContext())
                {
                    var newXy = context.Xys.Find(((XY)invocation.InvocationTarget).Id);
                    newXy.DoMethod();
                }
            }
            else
            {
                //Any other method goes straight through
                invocation.Proceed();
            }
        }
    }
    
    public class Calculation
    {
        private XY result = null;
                
        public XY Result {
            get {
                if (result == null) {
                    result = Calculate();
                }
                return result;
            }
        }
        
        private XY Calculate()
        {
          XY proxyResult;
          using (var context = new MyContext())
          {
              xyList = context.Xys.ToList();
              ...
              Xy realResult = xyList[calculatedIndex];
              proxyResult = (new ProxyGenerator()).CreateClassProxyWithTarget<XY>(realResult, new XYInterceptor());
              return proxyResult;
          }
        }
    }
