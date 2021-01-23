    Add-Type -TypeDefinition @'
    public class TestClass
    {
        public TestClass(int anInt, string aString = "") { }
        public TestClass(int anInt) { }
    }
    '@
    New-Object TestClass 1
