    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                const string json1 = "{ \"MyObject\" : { \"prop1\": \"Value1\", \"prop2\" : \"Value2\"}, \"Message\" : \"A message\"}";
                const string json2 = "{ \"MyObject\" : null, \"Message\" : \"A message\"}";
                var obj1 = JsonConvert.DeserializeObject<JsonObject>(json1);
                var obj2 = JsonConvert.DeserializeObject<JsonObject>(json2);
                Assert.IsInstanceOfType(obj1, typeof(JsonObject));
                Assert.IsInstanceOfType(obj2, typeof(JsonObject));
            }
        }
        public class MyObject
        {
            public MyObject(string prop1, string prop2)
            {
                this.prop1 = prop1;
                this.prop2 = prop2;
            }
            public string prop1 { get; private set; }
            public string prop2 { get; private set; }
        }
        public class JsonObject
        {
            public MyObject MyObject { get; set; }
            public string Message { get; set; }
        }
    }
