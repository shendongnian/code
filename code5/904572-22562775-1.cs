    internal class Program
    {
        private static void Main()
        {
            const string json = @"{
    ""Values"": {
        ""Category"": ""2"",
        ""Name"": ""Test"",
        ""Description"": ""Testing"",
        ""Expression"": ""[Total Items] * 100""
        }
    }";
            var myDto = JsonConvert.DeserializeObject<MyDto>(json);
        }
    }
    public class MyDto
    {
        public Dictionary<string, object> Values
        {
            get;
            set;
        }
    }
