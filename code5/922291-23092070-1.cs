        private static void SerializationTest()
        {
            List<test> test = new List<test>();
            test.Add(new test("testing1", 2));
            SerializeCollection("Test.txt", test, typeof(List<test>));
        }
