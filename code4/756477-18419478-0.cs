    class TestAttribute : Attribute {
        public TestAttribute(object value) { }
    }
    [Test(1.2m)]         // NOTE: CS0182
    class Example { }
