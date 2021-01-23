        class Foo
        {
            public string Value { get; set; }
            public string OtherValue { get; set; }
        }
       var dictionary = new Dictionary<string, Foo>();
       dictionary.Add("21", new Foo { Value = "value 1", OtherValue = "AAA" });
       dictionary.Add("23", new Foo { Value = "value 2", OtherValue = "BBB" });
       dictionary.Add("35", new Foo { Value = "value 3", OtherValue = "CCC" })
       var foo = dictionary["21"]; 
       //foo.OtherValue 
       //foo.Value
