            A a = new A()
            {
                b = "string",
                c = 12,
                d = true,
                e = new A()
                {
                    b = "another string",
                    c = 23
                }
            };
            var json = JsonConvert.SerializeObject(a); // create a json 
            dynamic newObj = JsonConvert.DeserializeObject(json);// create a dynamic object
