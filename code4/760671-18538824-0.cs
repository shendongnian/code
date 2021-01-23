    public class MyClassOfStuff
    {
        Type SpecificName1 {get;set;}
        Type SpecificName2 {get;set;}
        public static MyClassOfStuff Parse(Type[] value)
        {
            Type specificName1 = values[0];
            Type specificName2 = values[1];
            ...
            Type specificNameN = values[n];
        }
    }
     void OriginalMethodSignature(Type[] values)
    {
        var mystuff = MyClassOfStuff.Parse(values);
    }
