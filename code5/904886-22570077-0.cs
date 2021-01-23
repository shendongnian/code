    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class DataClass
    {
    	public string Prop1 { get; set; }
    	public string Prop2 { get; set; }
    	public string Prop3 { get; set; }
        public int Prop4 { get; set; }
        public int? Prop5 { get; set; }
    }
    
    public class Test
    {
    	public static void Main()
    	{
    	    var cls = new DataClass() { Prop1 = null, Prop2 = string.Empty, Prop3 = "Value" };
    	    UpdateIfNotSet(cls, x => x.Prop1, UpdateMethod);
    	    UpdateIfNotSet(cls, x => x.Prop2, UpdateMethod);
    	    UpdateIfNotSet(cls, x => x.Prop3, UpdateMethod);
            UpdateIfNotSet(cls, x => x.Prop4, (x) => -1);
            UpdateIfNotSet(cls, x => x.Prop5, (x) => -1);
            Console.WriteLine(cls.Prop1);  // prints "New Value for Prop1"
            Console.WriteLine(cls.Prop2);  // prints "New Value for Prop2"
            Console.WriteLine(cls.Prop3);  // prints "Value"
            Console.WriteLine(cls.Prop4);  // prints "0"
            Console.WriteLine(cls.Prop5);  // prints "-1"
        }
    
        public static void UpdateIfNotSet<TOBJ, TPROP>(TOBJ obj, 
                               Expression<Func<TOBJ, TPROP>> prop, 
                               Func<string, TPROP> updateMth)
        {
            var currentValue = prop.Compile().DynamicInvoke(obj);
            var strValue = currentValue as string; // Need to convert to string gracefully so that check against empty is possible
            if (currentValue == null || (strValue != null && strValue.Length == 0))
            {
                var memberAcc = (MemberExpression)prop.Body;
                var propInfo = (PropertyInfo)memberAcc.Member;
                propInfo.SetMethod.Invoke(obj, new object[] { updateMth(propInfo.Name) });
            }
        }
    
        public static string UpdateMethod(string propName)
        {
            return "New Value for " + propName;
        }
    }
