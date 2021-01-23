    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace CustomAttributeTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var customCompo = new Component();
                customCompo.Test();
    
                //System.Reflection.MemberInfo info = typeof(Component);
                //object[] attributes = info.GetCustomAttributes(true);
                //for (int i = 0; i < attributes.Length; i++)
                //{
                //    System.Console.WriteLine(attributes[i]);
    
                //}
                Console.ReadLine();
    
            }
        }
    
        [CustomAttribute(true)]
        public class Component
        {
            public void Test()
            {
    
                System.Console.WriteLine("Component contructed");
    
                var member = typeof(Component);
                foreach (object attribute in member.GetCustomAttributes(true))
                {
                    if (attribute is CustomAttribute)
                    {
                        //noop
                    }
                }
    
    
            }
        }
    
    
        [AttributeUsage(AttributeTargets.All)]
        public class CustomAttribute : Attribute
        {
    
            private bool _value;
    
            //this constructor specifes one unnamed argument to the attribute class
            public CustomAttribute(bool value)
            {
                _value = value;
                Console.WriteLine(this.ToString());
    
            }
    
    
            public override string ToString()
            {
                string value = "The boolean value stored is : " + _value;
                return value;
            }
    
    
    
    
        }
    
    
    
    }
