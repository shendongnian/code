    using System.Runtime.InteropServices;
    
    namespace InteropTest
    {
        [ComVisible(true)]
        public struct TestStruct
        {
            [MarshalAs(UnmanagedType.Struct)]
            public object testField;
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.AutoDual)]
        [Guid("6E0DD830-1BF9-41E0-BBEB-4CC314BBCB55")]
        public class TestClass
        {
            public void GetTestStruct(ref TestStruct p)
            {
                double? testValue = 1.1;
                p.testField = testValue;
            }
        }
    }
