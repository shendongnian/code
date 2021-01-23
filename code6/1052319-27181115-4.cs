            Person[] coll = new Person[] 
            {
                new Person
                {
                    ID = 123456789,
                    Name = "John Doe",
                    Tag = Tag.CD,
                    Sex = Sex.MM
                },
                new Person
                {
                    ID = 123456789,
                    Name = "Jane Doe",
                    Tag = Tag.AB,
                    Sex = Sex.FM
                }
            };
            var filteredSex = coll.Where(x => x.Sex == Sex.MM);
