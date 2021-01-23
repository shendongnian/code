    public class ClassBase
    {
        virtual protected string AboutToReturnName(string result) 
        {
           return name;    
        }
        public string Name 
        { 
          get 
          {
            var result = "MyName";
            return AboutToReturnName(result);
          }
        }
    }
