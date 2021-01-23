    [TestClass]
    public class StringObjectMapperTest
    {
        private Dictionary<string, Setter> mapping = new Dictionary<string, Setter>();
        public delegate void Setter(string v);
        [TestMethod]
        public void TestMethod1()
        {
            string string1 = "string1";
            string string2 = "string2";
            string text1 = "text1";
            string text2 = "text2";
            Add("STRING1", x => string1 = x);
            Add("STRING2", x => string2 = x);
            Assert.AreNotEqual(text1, string1);
            Set("STRING1", text1);
            Assert.AreEqual(text1, string1);
            Assert.AreNotEqual(text2, string2);
            Set("STRING2", text2);
            Assert.AreEqual(text2, string2);
        }
        private void Set(string key, string value)
        {
            Setter set = mapping[key];
            set(value);
        }
        private void Add(string p, Setter del)
        {
            mapping.Add(p, del);
        }
    }
