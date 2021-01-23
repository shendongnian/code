    public static class TestDictionaryJson
    {
        public static void Test()
        {
            var dict = new Dictionary<MyValue, int>();
            dict[(new MyValue("A", "A"))] = 1;
            dict[(new MyValue("B", "B"))] = 2;
            var myContainer = new MyContainer() { MyValue = new MyValue("A Property", "At the top level"), Dictionary = dict };
            var json = JsonConvert.SerializeObject(myContainer, Formatting.Indented);
            Debug.WriteLine(json);
            try
            {
                var newContainer = JsonConvert.DeserializeObject<MyContainer>(json);
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString()); // No assert - no exception is thrown.
            }
            try
            {
                var dictjson = JsonConvert.SerializeObject(dict, Formatting.Indented);
                Debug.WriteLine(dictjson);
                var newDict = JsonConvert.DeserializeObject<Dictionary<MyValue, int>>(dictjson);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught expected exception deserializing dictionary directly: " + ex.ToString());
            }
        }
    }
