    public class Program 
    {
    static void Main(string[] args)
            {
                Foo myFoo = new Foo();
                myFoo.Bar = new Bar();
                myFoo.Bar.Name = "Jinal";
                myFoo.Code = "Ths is test";
                // By Using infer
                string FooCode = Convert.ToString(getItem(myFoo, "Code")); // returns "myFoo"
                string BarName = Convert.ToString(getItem(myFoo.Bar, "Name"));
    
                // Using Reflection
                Type ex = typeof(Program);
                MethodInfo mi = ex.GetMethod("getItem");
                object foo = myFoo;
                var methodgetItem =  mi.MakeGenericMethod(foo.GetType());
                string result = Convert.ToString(methodgetItem.Invoke(null, new object[]{foo , "Code"}));
    
                object bar = myFoo.Bar;
                var methodgetItem1 = mi.MakeGenericMethod(bar.GetType());
                string result1 = Convert.ToString(methodgetItem1.Invoke(null, new object[] {bar , "Name" }));
    
                Console.ReadLine();
            }
    
            public static object getItem<T>(T obj, string _Value)
            {
                try
                {
                    object _Resolved = null;
                    _Resolved = obj.GetType().GetProperty(_Value).GetValue(obj, null);
                    return _Resolved;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
     }
