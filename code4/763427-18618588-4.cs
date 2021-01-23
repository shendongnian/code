    public class Program
    {
        private const string xml = @"
            <Object>
              <Id>12</Id>
              <Title>mytitle</Title>
              <Visible>false</Visible>
            </Object>";
        private static void Main ()
        {
            var serializer = new XmlSerializer(typeof(Root));
            var root = (Root)serializer.Deserialize(new StringReader(xml));
            Console.WriteLine(JsonConvert.SerializeObject(root, Formatting.Indented));
            Console.ReadKey();
        }
    }
