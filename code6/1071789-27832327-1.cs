    public static class TestNoParameterlessConstructor
    {
        public static void Test()
        {
            var derived = new DerivedClass { Id = 1, NoParameterlessConstructor = new NoParameterlessConstructor("Test") };
            var xml = XmlSerializationHelper.GetXml(derived, DerivedClass.DerivedClassXmlSerializer);
            Debug.WriteLine(xml);
        }
    }
