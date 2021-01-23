    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E3B77594-8168-4C12-9041-9A7D3FE4035F")]
    public interface ITestClass
    {
        void GetTestStruct(ref TestStruct p);
    }
    
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(ITestClass))]
    [Guid("6E0DD830-1BF9-41E0-BBEB-4CC314BBCB55")]
    public class TestClass : ITestClass
    {
        public void GetTestStruct(ref TestStruct p)
        {
            double? testValue = 1.1;
            p.testField = testValue;
        }
    }
