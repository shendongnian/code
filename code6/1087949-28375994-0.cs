    namespace ClassLibrary2
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("BBBBBBBB-BBBB-BBBB-BBBB-BBBBBBBBBBBB")]
        public interface MyCOMInterface
        {
            void MyMethod();
        }
    
        [ComVisible(true)]
        [Guid("AAAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA")]
        [ClassInterface(ClassInterfaceType.None)]
        public class Class2 : ClassLibrary1.Class1, MyCOMInterface
        {
        }
    }
