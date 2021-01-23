            Person[] coll = new Person[] 
            {
                new Person
                {
                    ID = 123456789,
                    Name = "John Doe",
                    Tag = "CD",
                    Sex = "MM"
                },
                new Person
                {
                    ID = 123456789,
                    Name = "Jane Doe",
                    Tag = "AB",
                    Sex = "FM"
                }
            };
            var filteredSex = coll.Where(x => x.Sex == "MM");
