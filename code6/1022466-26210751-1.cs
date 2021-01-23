            Data = new Dictionary<string, object>();
            Data.Add("someBool", true);
            Data.Add("someInt", 42);
            Data.Add("someString","test");
            IList listString = ReturnList("someString");
            IList listInt = ReturnList("someInt");
            IList listBool = ReturnList("someString");
