    [XmlRoot("A", Namespace="ATestNameSpace")]
    public class ClassA
    {
        [XmlText]
        public string Value { get; set; }
    }
    public class MyObject
    {
        public string ObjectValue1 { get; set; }
        public string ObjectValue2 { get; set; }
    }
    public class TestClass
    {
        public static void Test()
        {
            var root1 = RequestRootHelper.Create(new ClassA { Value = "Some data" });
            var root2 = RequestRootHelper.Create(new List<MyObject> { new MyObject { ObjectValue1 = "Object Value 1-1", ObjectValue2 = "Object Value 2-1" }, new MyObject { ObjectValue1 = "Object Value 1-2", ObjectValue2 = "Object Value 2-2" } });
            var serializer = new RequestRootXmlSerializer(new[] { typeof(ClassA), typeof(List<ClassA>), typeof(MyObject), typeof(List<MyObject>) });
            TestRootSerialization(root1, serializer);
            TestRootSerialization(root2, serializer);
        }
        private static void TestRootSerialization<T>(RequestRoot<T> root, RequestRootXmlSerializer serializer)
        {
            var xml1 = serializer.SerializeToString(root);
            Debug.WriteLine(xml1);
            var root11 = serializer.DeserializeFromString(xml1);
            Debug.Assert(root.GetType() == root11.GetType()); // NO ASSERT
            var xml11 = serializer.SerializeToString(root11);
            Debug.WriteLine(xml11);
            Debug.Assert(xml1 == xml11); // NO ASSERT
        }
    }
