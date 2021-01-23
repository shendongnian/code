    public class Validator
       {
           public AndClass IsNumber(int val)
           {
               int n;
               bool isNumeric = int.TryParse(val.ToString(), out n);
               if (isNumeric)
                   return new AndClass( Convert.ToInt32(val));
               throw new Exception(";The value should be number";);
           }
       }
     
