    public void BuildPerson()
        {
            var list = new People
            {
                PersonList = new List<List<Person>>
                {
                    new List<Person>
                {
                    new Person
                    {
                        Name = "test",
                        Age = 21
                    }          
                },
                 new List<Person>
                {
                    new Person
                    {
                        Name = "test2",
                        Age = 22
                    }
                },
                 new List<Person>
                {
                    new Person
                    {
                        Name = "test3",
                        Age = 23
                    }
                }
                }
            };
            string output = JsonConvert.SerializeObject(list);
            var objList = JsonConvert.DeserializeObject<People>(output);
            var ListObjs = objList.PersonList;
            foreach(var obj in ListObjs)
            {
                var objj = obj.ToArray();
                foreach(var person in objj)
                {
                    string name = person.Name;
                    int age = person.Age;
                }
            }
        }
