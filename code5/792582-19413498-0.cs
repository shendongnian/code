    public class RootClass 
    {
        public RootClass(int rootProperty)
        {
            this.RootProperty = rootProperty;  
        }
        public int RootProperty {get; set;}
    }
    public class SubClass : RootClass
    {
                                                               v--- call the base constructor
       public SubClass(int rootProperty, string subProperty) : base(rootProperty)
       {
           this.SubProperty = subProperty; 
       }
       
       public string SubProperty {get; set}
    }
