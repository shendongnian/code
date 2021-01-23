    enum TestEnum
    {
        DummyValue
    }
    
    class TestClass
    {
        public int IntValue;
        public decimal DecimalValue;
        public int? NullableInt;
        public TestEnum EnumValue;
        public TestEnum? NullableEnumValue;
        public TestClass ObjectValue;
    }
    
    [TestFixture]
    public class DataObjectBinderFixture
    {
        private TestClass _testObject;
    
        private void SetFieldValue(string fieldName, object value)
        {
            var fieldInfo = typeof (TestClass).GetField(fieldName);
            ReflectionUtils.SetFieldValue(fieldInfo, _testObject, value);
        }
    
        [Test]
        public void TestSetValue()
        {
            _testObject = new TestClass();
    
            SetFieldValue("IntValue", 2.19);
            SetFieldValue("IntValue", DBNull.Value);
            SetFieldValue("DecimalValue", 1);
    
            SetFieldValue("NullableInt", null);
            SetFieldValue("NullableInt", 12);
    
            SetFieldValue("EnumValue", TestEnum.DummyValue);
            SetFieldValue("EnumValue", 0);
    
            SetFieldValue("NullableEnumValue", TestEnum.DummyValue);
            SetFieldValue("NullableEnumValue", null);
            SetFieldValue("NullableEnumValue", 0);
            SetFieldValue("NullableEnumValue", DBNull.Value);
    
            SetFieldValue("ObjectValue", DBNull.Value);
    
        }
    }
