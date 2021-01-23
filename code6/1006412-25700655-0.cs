    namespace ConsoleApplication1
    {
    
      using System;
    [AttributeUsage(AttributeTargets.All)]
    public class AllowAttribute : System.Attribute 
    {
       public readonly string SomeString;
    
       public AllowAttribute(string someString)  // your string is passed in custom attribute 
       {
          this.SomeString = someString;
       }
    
     
    }
    public interface IAllowAttributeInvoker
    {
      object AllowAttributeInvokeMethod<T>(string methodName, T classInstance, object[] parametersArray);
    
    }
    
    public  class AllowAttributeInvoker: IAllowAttributeInvoker
    {
      public object AllowAttributeInvokeMethod<T>(string methodName, T classInstance, object[] parametersArray)
      {
        System.Reflection.MemberInfo info = typeof(T).GetMethod(methodName);
        if (IsAttributeValid(info))
        {
          var method = (typeof (T)).GetMethod(methodName);
          Console.WriteLine("Invoking method");
          var result = method.Invoke(classInstance, parametersArray);
    
          return result;
        }
        else
        {
          Console.WriteLine("Can not invoke this method.");
        }
        return null;
      }
    
    
      private static bool IsAttributeValid(MemberInfo member)
       {
            foreach (object attribute in member.GetCustomAttributes(true))
            {
                if (attribute is AllowAttribute && ((AllowAttribute)attribute).SomeString == "Valid")
                {
                   return true;
                }
            }
          return false;
       }
    }
    
      
      public class EmployeeService :AllowAttributeInvoker
      {
    
        public object PaySalary()
        {
          return AllowAttributeInvokeMethod("PaySalaryInvoke", this, null);
        }
    
        [Allow("Valid")]
        public void PaySalaryInvoke()
        {
    
          Console.WriteLine("Salary Paid.");
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
          Console.ReadLine();
    
          EmployeeService service = new EmployeeService();
          service.PaySalary();
          Console.ReadLine();
    
        }
      }
    }
