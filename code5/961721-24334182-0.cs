    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Dynamic;
    
    public class MyClass1 {
    
        public int MyIntProperty { get; set; }
        public string MyStringProperty { get; set; }
    
        [MyCustom()]
        public MyClass2 MyClass2Property { get; set; }
    }
    
    public class MyClass2 {
    
        public int MyOtherIntProperty { get; set; }
        public string MyOtherStringProperty { get { return "oooh, fancy"; } set {} }
        public bool MyOtherBoolProperty { get; set; }
    
    }
    
    public static class MyGenericClass<T> where T : class {
    
        public static T MyGenericMethod() {
            T o = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] pi = typeof(T).GetProperties();
    
            for (int i = 0; i < pi.Count(); i++) {
                if (pi[i].GetCustomAttributes(true).Any() && pi[i].GetCustomAttributes(true).Where((x) => x is MyCustomAttribute).Any()) {
                    //How to proceed ?
                    var c = Activator.CreateInstance(pi[i].PropertyType);
                    Type t = typeof(MyGenericClass<>);
                    Type genericType = t.MakeGenericType(new System.Type[] { pi[i].PropertyType });
                    MethodInfo m = genericType.GetMethod(MethodInfo.GetCurrentMethod().Name);
                    c = m.Invoke(null, null);
                    pi[i].SetValue(o, c, null);
                } else {
                    //Normal property assignment.
                }
            }
            return o;
        }
    }
    
    public class Program {
    
        public static void Main(string[] args) {
            MyClass1 mc1 = MyGenericClass<MyClass1>.MyGenericMethod();
            //Do something with mc1
            Console.WriteLine(mc1.MyClass2Property.MyOtherStringProperty);
            Console.ReadLine();
        }
    
    }
    
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class MyCustomAttribute : Attribute {
    
    }
