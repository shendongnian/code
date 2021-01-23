    public static void CompareObjects(object expected, object actual)
    {
        foreach (PropertyInfo propertyInfo in expected.GetType().GetProperties())
        {
            var expectedValue = propertyInfo.GetValue(expected, null);
            var actualValue = propertyInfo.GetValue(actual, null);
            Assert.AreEqual(expectedValue, actualValue, "Comparing property " + propertyInfo.Name);
        }
        foreach (FieldInfo fieldInfo in expected.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            Assert.AreEqual(fieldInfo.GetValue(expected), fieldInfo.GetValue(actual), "Comparing field " + fieldInfo.Name);
        }
    }
