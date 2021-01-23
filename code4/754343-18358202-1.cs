    [TestFixture]
    public class IsoDateSerializationTest
    {
        [Test]
        public void Test()
        {
            JToken jtoken = JObject.Parse(@"{ IsoDate: ""1994-11-05T13:15:30Z"" }");
            Type deserializeType = typeof (MessageWithIsoDate);
            JsonSerializer serializer = new JsonSerializer();
            object obj;
            using (var jsonReader = new JTokenReader(jtoken))
            {
                obj = serializer.Deserialize(jsonReader, deserializeType);
            }
            MessageWithIsoDate msg = obj as MessageWithIsoDate;
            Assert.That(msg.IsoDate, Is.EqualTo("1994-11-05T13:15:30Z"));
        }
    }
    public class MessageWithIsoDate
    {
        public String IsoDate { get; set; }
    }
