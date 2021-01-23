    using Newtonsoft.Json;
    using NUnit.Framework;
    public class DTO
    {
        public string Field1;
        public int Field2;
    }
    public class JsonDeserializationTests
    {
        [Test]
        public void JsonCanBeDeserializedToDTO()
        {
            string json = "{ 'Field1':'some text', 'Field2':45 }";
            var data = JsonConvert.DeserializeObject<DTO>(json);
            Assert.That(data.Field1 == "some text");
            Assert.That(data.Field2 == 45);
        }
        [Test]
        public void JsonCanBeDeserializedToDynamic_AndConvertedToDTO()
        {
            string json = "{ 'Field1':'some text', 'Field2':45 }";
            var dynamicData = JsonConvert.DeserializeObject<dynamic>(json);
            var data = new DTO { Field1 = dynamicData["Field1"], Field2 = dynamicData["Field2"] };
            Assert.That(data.Field1 == "some text");
            Assert.That(data.Field2 == 45);
        }
    }
