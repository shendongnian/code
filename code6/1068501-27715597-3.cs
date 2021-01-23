    public static class TestFlatten
    {
        public static void Test()
        {
            string jsonString = @"{
                ""data"": [
                    {
                        ""company"": {
                            ""ID"": ""12345"",
                            ""location"": ""Some Location""
                        },
                        ""name"": ""Some Name""
                    }
                ]
            }";
            JObject obj = JObject.Parse(jsonString);
            var newObj = (JObject)obj.PromoteNamedPropertiesToParents("company");
            Debug.WriteLine(newObj);
        }
    }
