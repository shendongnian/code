    [ProtoContract]
    public class TempClass 
    {
        [ProtoMember(1)]
        public Dictionary<string, int> data;
        [ProtoMember(2)]
        public string Version;
        public TempClass() { }
    }
    [TestClass]
    public class serializationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string newVersion = "someVersion";
            TempClass original = new TempClass()
            {
                data = new Dictionary<string,int>
                {
                    {"a", 2},
                    {"b", 3},
                    {"c", 1},
                },
                Version = newVersion
            };
            byte[] serialized = Serialize(original);
            TempClass deserialized = Deserialize(serialized);
            // Validate
            foreach (var pair in original.data)
            {
                Assert.IsTrue(deserialized.data.ContainsKey(pair.Key));
                Assert.AreEqual(pair.Value, deserialized.data[pair.Key]);
            }
            Assert.AreEqual(newVersion, original.Version, "original mapping version not set correctly");
            Assert.AreEqual(newVersion, deserialized.Version, "deserialized version doesn't match");
        }
        private static TempClass Deserialize(byte[] serialized)
        {
            TempClass deserialized;
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(serialized, 0, serialized.Length);
                ms.Position = 0;
                deserialized = Serializer.Deserialize<TempClass>(ms);
            }
            return deserialized;
        }
        private static byte[] Serialize(TempClass mapping)
        {
            byte[] serialized;
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, mapping);
                serialized = ms.ToArray();
            }
            return serialized;
        }
    }
