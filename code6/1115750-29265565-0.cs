    partial class SingletonClass
    {
        public static partial class ContainerClass
        {
            abstract class BaseClass
            {
            }
        }
    }
    partial class SingletonClass
    {
        static partial class ContainerClass
        {
            class DerivedClass : BaseClass
            {
            }
        }
    }
