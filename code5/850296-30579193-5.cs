    class Holder
        {
            public List<Base> Objects { get; set; }
        }
    string json = @"
            [
                {
                    ""Objects"" : 
                    [
                        { ""ObjType"": 1, ""Id"" : 1, ""Foo"" : ""One"" },
                        { ""ObjType"": 1, ""Id"" : 2, ""Foo"" : ""Two"" },
                    ]
                },
                {
                    ""Objects"" : 
                    [
                        { ""ObjType"": 2, ""Id"" : 3, ""Bar"" : ""Three"" },
                        { ""ObjType"": 2, ""Id"" : 4, ""Bar"" : ""Four"" },
                    ]
                },
            ]";
    
                List<Holder> list = JsonConvert.DeserializeObject<List<Holder>>(json);
                string serializedAgain = JsonConvert.SerializeObject(list);
                Debug.WriteLine(serializedAgain);
