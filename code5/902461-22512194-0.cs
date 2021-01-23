    namespace ConsoleApplication15
    {
      using System;
      using Castle.DynamicProxy;
    
      public class Test
      {
        private SubTestClass subTestClass;
    
        public virtual string Status
        {
          get
          {
            return this.subTestClass.SubStatus;
          }
    
          set
          {
            this.subTestClass.SubStatus = value;
          }
        }
    
        public int Data { get; set; }
      }
    
      public class SubTestClass
      {
        public string SubStatus { get; set; }
      }
    
      public class Program
      {
        public static void Main(string[] args)
        {
          var proxyGenerator = new ProxyGenerator();
    
          var testObject = proxyGenerator.CreateClassProxy<Test>(new MyInter());
    
    
          if (testObject.Status != null)
          {
            Console.WriteLine("Working");
          }
        }
    
      }
    
      public class MyInter : IInterceptor
      {
        public void Intercept(IInvocation invocation)
        {
          if (invocation.Method.ReturnType == typeof(string))
          {
            invocation.ReturnValue = string.Empty;
          }
        }
      }
    }
