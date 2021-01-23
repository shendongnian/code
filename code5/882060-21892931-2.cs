    public class MyClass
    {
        public IType1 Type1 { get; set; }
        public IType2 Type2 { get; set; }
        public IType3 Type3 { get; set; }
        public MyClass(IType1 type1, IType2 type2, IType3 type3)
        {
            Type1 = type1;
            Type2 = type2;
            Type3 = type3;
        }
    }
    public class MyOtherClass
    {
        public IType1 Type1 { get; set; }
        public IType2 Type2 { get; set; }
        public IType3 Type3 { get; set; }
        public MyOtherClass(IType1 type1, IType2 type2, IType3 type3)
        {
            Type1 = type1;
            Type2 = type2;
            Type3 = type3;
        }
    }
    public class MyThirdType : IType3
    {
    }
    public class MySecondType : IType2
    {
    }
    public class MyFirstType : IType1
    {
    }
    public interface IType3
    {
    }
    public interface IType2
    {
    }
    public interface IType1
    {
    }
