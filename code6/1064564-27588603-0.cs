    public static class DataContractJsonSerializerPolymorphismTest
    {
        public static void Test()
        {
            var a1 = new A() { s1 = "A" };
            var b1 = new B() { s2 = "B" };
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(IObject));
            var jsona1 = DataContractJsonSerializerHelper.GetJson(a1, serializer);
            var jsonb1 = DataContractJsonSerializerHelper.GetJson(b1, serializer);
            Debug.WriteLine(jsona1);
            Debug.WriteLine(jsonb1);
            var newa1 = DataContractJsonSerializerHelper.GetObject<IObject>(jsona1, serializer);
            Debug.Assert(newa1.GetType() == a1.GetType()); // No assert
        }
    }
