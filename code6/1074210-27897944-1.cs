        List<Dictionary<String, Object>> Details = new List<Dictionary<string, object>>
        {
            new Dictionary<string,object>
            {
                {"abc" , "def"},
                {"123", 234}
            },
            new Dictionary<string,object>
            {
                {"abc1" , "def1"},
                {"1231", 2341}
            }
        };
            // serializing to: [{"abc":"def","123":234},{"abc1":"def1","1231":2341}]
            string json = JsonConvert.SerializeObject(Details);
            // de-serializing to a new List<Dictionary<String, Object>>.
            List<Dictionary<String, Object>> newDic = JsonConvert.DeserializeObject<List<Dictionary<String, Object>>>(json);
