        public static void Test2()
        {
            List<BaseClass> list = new List<BaseClass>();
            list.Add(new BaseClass());
            list.Add(new MidClass());
            list.Add(new DerivedClass1());
            list.Add(new DerivedClass2());
            var serializer = XmlSerializerWithKnownDerivedTypesCreator.CreateKnownTypeSerializer(list.GetType(), new Type[] { typeof(BaseClass) });
            string xml = XmlSerializationHelper.GetXml(list, serializer, false);
            Debug.WriteLine(xml);
            // No assert below:
            Debug.Assert(object.ReferenceEquals(serializer, XmlSerializerWithKnownDerivedTypesCreator.CreateKnownTypeSerializer(list.GetType(), new Type[] { typeof(BaseClass) })));
        }
