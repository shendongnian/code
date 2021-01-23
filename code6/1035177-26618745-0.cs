    public interface ICommonProperty
    {
        int SomeCommonProperty {get;set;}
    }
    public class A : ICommonProperty
    {
        public int SomeCommonProperty { get; set; }
    }
    public class B : ICommonProperty
    {
        public int SomeCommonProperty { get; set; }
    }
    public static List<T> MethodToTakeListOfAboveTypes<T>(this List<T> destinationList, List<T> sourceList, string someProp) where T : ICommonProperty
