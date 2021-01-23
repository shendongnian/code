    }
    public class A : ITest
    {
        private A()
        {
        }
        public static ITest Create()
        {
            return new A();
        }
    }
