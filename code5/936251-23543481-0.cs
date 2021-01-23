    using Parse;
    using System.Threading.Tasks;
    namespace ExperiorWrapper
    {
    public class ParseFunctions
    {
        public static async Task testParse()
        {
            ParseClient.Initialize("xxxx", "xxxx");
            var testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            await testObject.SaveAsync();
        }
    }
    }
