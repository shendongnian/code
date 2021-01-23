        private static void SerializationTest()
        {
            const string fileName = "Test.txt";
            var tests = new List<test> {new test("testing1", 2)};            
            SerializeCollection(fileName, tests);
        }
        public static void SerializeCollection<T>(string fullFileName, IEnumerable<T> items)
        {
            var writer = new XmlSerializer(items.GetType());            
            var file = new StreamWriter(fullFileName);
            writer.Serialize(file, items);
        }
