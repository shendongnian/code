    interface ITheInterface{}
    class TheClass : ITheInterface{}
    class OtherClass {}
    public static void Main(string[] args)
    { 
        NextMethod(new TheClass());
        NextMethod(new OTherClass());
        
    }
    
    public static NextMethod(dynamic d)
    {
        //works on the first call but not the second
        TheInterface ti = (ITheInterface)d;
        
    } 
