    //In Class3.cs
    public partial class Class3
    {
        public enum Type { Order, Inventory }
        //...
    }
    
    //In IProvidedsGetData.cs
    partial class Class3
    {
        private interface IProvidesGetData
        {
            object getData(); 
        }
    }
    
    //In Class1.cs
    partial class Class3
    {
        private class Class1 : IProvidesGetData 
        {
            /* ... */ 
        }
    }
    
    //in Class2.cs
    partial class Class3
    {
        private class Class2 : IProvidesGetData 
        {
            /* ... */ 
        }
    }
