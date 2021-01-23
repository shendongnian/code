    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class WorkAttribute : System.Attribute
        {
            public string Message;
    
            public WorkAttribute(string message)
            {
                this.Message = message;
            }
        }
    
        class Program
        {
            [Work("WorkMessage")]
            public void test()
            {
            }
            
            static void Main()
            {
                foreach (MethodInfo methodInfo in typeof(Program).GetMethods())
                {
                    WorkAttribute workAttribute = methodInfo.GetCustomAttribute<WorkAttribute>();
                    if (workAttribute != null)
                    {
                        Console.WriteLine(workAttribute.Message);// Should print "WorkMessage", but Message is null.
                    }
    
                    Console.ReadLine();
                }
            }
        }
    }
