    public interface IOverride
    {
        string StandardProperty1 { get; set; }
        string StandardProperty2 { get; set; }
        List<string> StandardProperty3 { get; set; }
        string OverrideProperty1 { get; set; }
        string OverrideProperty2 { get; set; }
        List<string> OrderedProperty3 { get; set; }
    }
    class ClassA : SuperClass { }
    class ClassB : SuperClass { }
    class ClassC : SuperClass { }
    class SuperClass : IOverrideProperty
    {
        string StandardProperty1 { get; set; }
        string StandardProperty2 { get; set; }
        List<string> StandardProperty3 { get; set; }
        string OverrideProperty1 { get; set; }
        string OverrideProperty2 { get; set; }
        List<string> OrderedProperty3 { get; set; }
        
        string Property1 
        { 
            get
            {
                if (condition)
                    return OverrideProperty1;
                else
                    return StandardProperty1;
            } 
            set
            {
                 if (condition)
                    OverrideProperty1 = value;
                else
                    StandardProperty1 = value;
            }
        
            //Same for Property2 and 3
    }
