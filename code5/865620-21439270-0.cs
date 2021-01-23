    public class OuterClass
    {
        public static InnerClass GetInnerClass()
        {
            return new InnerClassImpl() { MyProperty = 1 };
        }
    
        public interface InnerClass
        {
            int MyProperty { get; }
        }
        private class InnerClassImpl : InnerClass
        {
            public int MyProperty { get; set; }
        }
    }
