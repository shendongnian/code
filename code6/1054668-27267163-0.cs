    namespace Private
    {
        internal interface IMyInterface
        {
            void InterfaceMethod();
        }
    
        public abstract class MyCommonImpl : IMyInterface
        {
            internal MyCommonImpl()
            {
                // internal ctor to stop callers constructing
            }
    
            void IMyInterface.InterfaceMethod()
            {
                Console.WriteLine("InterfaceMethod");
            }
    
            internal abstract void CommonAbstract();
        }
    
        public class MyImplA : MyCommonImpl
        {
            internal override void CommonAbstract()
            {
                ((IMyInterface)this).InterfaceMethod();
                Console.WriteLine("CommonAbstract");
            }
    
            public void ImplAMethod()
            {
                CommonAbstract();
                Console.WriteLine("ImplAMethod");
            }
        }
    }
