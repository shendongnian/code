        class Program
        {
        static void Main(string[] args)
        {
            TestClass _testClass = new TestClass();
            Type _testClassType = _testClass.GetType();
            // Get attributes:
            // Check if the instance class has any attributes
            if (_testClassType.CustomAttributes.Count() > 0)
            {
                // Check the attribute which matches TestClass
                CustomAttributeData _customAttribute = _testClassType.CustomAttributes.SingleOrDefault(a => a.AttributeType == typeof(TestAttribute));
                if (_customAttribute != null)
                {
                    // Loop through all constructor arguments
                    foreach (var _argument in _customAttribute.ConstructorArguments)
                    {
                        // value will now hold the value of the desired agrument
                        var value = _argument.Value;
                        // To get the original type:
                        //var value = Convert.ChangeType(_argument.Value, _argument.ArgumentType);
                    }
                }
            }
            Console.ReadLine();
        }
    }
    [TestAttribute("test")]
    public class TestClass
    {
    }
    public class TestAttribute : System.Attribute
    {
        public TestAttribute(string _test)
        {
        }
    }
