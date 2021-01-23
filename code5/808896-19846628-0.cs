    class values
    {
        IDictionary<string, string> list = new Dictionary<string, string>()
        {
            { "value1", "one" },
            { "value2", "two" },
            { "value3", "three" },
        };
    
        private void method()
        {
            foreach(var pair in list)
            {
                sqlCommand.Parameters.AddWithValue("@"+pair.Key, pair.Value);
            }
        }
    }
