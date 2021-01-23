    [TestClass]
    public class JavascriptSerializerTest
    {
        [TestMethod]
        public void TestEscapeOnJavascriptSerializer()
        {
            const string replaceableToken = "[replace_here]";
            var user = @"domain\user".Replace(@"\", replaceableToken);
            const string password = "123456";
            var token = new Token { Value = string.Format("{0};{1}", user, password) };
            var serializer = new JavaScriptSerializer();
            
            var jsonObject = serializer.Serialize(token);
            jsonObject = jsonObject.Replace(replaceableToken, @"\");
            Assert.AreEqual("{\"Value\":\"domain\\user;123456\"}", jsonObject);
        }
    }
    public class Token
    {
        public string Value { get; set; }
    }
