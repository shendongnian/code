    public class SomeBaseClass { }
    public class SomeClass : SomeBaseClass { }
    public class AnotherClass : SomeBaseClass { }
    
    public class BaseData<TType> where TType : SomeBaseClass
    {
        protected TType mMember;
        public BaseData() { }
        public BaseData(TType member)
            : this()
        {
            mMember = member;
        }
        public TType GetMember()
        {
            return mMember;
        }
    }
    
    public class Data : BaseData<SomeClass>
    {
        public Data()
            : base(new SomeClass())
        {
        }
        // no need to implement GetMember(); base class has it covered
    }
