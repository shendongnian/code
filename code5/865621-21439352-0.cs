    public class OuterClass
    {
        public static IInnerClass GetInnerClass()
        {
            return new InnerClass() { MyProperty = 1 };
        }
        public interface IInnerClass
        {
            int MyProperty { get; }
        }
        private class InnerClass : IInnerClass
        {
            public int MyProperty { get; set; }
        }
    }
