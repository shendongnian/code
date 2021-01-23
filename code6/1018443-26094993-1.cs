            var someObj = new DummyClass
            {
                ID = Guid.NewGuid(),
                IntID = 102934,
                Name = "My Super Hero Name"
            };
            string json = JsonConvert.SerializeObject(someObj);
            Console.WriteLine(json);
            var otherObj = JsonConvert.DeserializeObject<DummyClass>(json);
            Console.WriteLine(otherObj.ID);
            Console.ReadKey();
