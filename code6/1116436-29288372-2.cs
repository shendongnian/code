    public class DynamicMethod
    {        
         public string ClassName { get; set; }
         public string MethodName { get; set; }
         public object[] Parameters { get; set; }
         public static object InvokeMethod(DynamicMethod methodInfo)
         {
             var magicType = Type.GetType(methodInfo.ClassName);
             var magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
             var magicMethod = magicType.GetMethod(methodInfo.MethodName);
             return magicMethod.Invoke(magicConstructor, methodInfo.Parameters);
         }
    }
    public class Example
    {
        public static void main()
        {
            var d1 = new DynamicMethod
            {
                ClassName = "SomeClass",
                MethodName = "Add",
                Parameters = new object[] { 1, 2 }
            };
            var returnedValue = DynamicMethod.InvokeMethod(d1);   
            Console.WriteLine(returnedValue.ToString());
        }
         
