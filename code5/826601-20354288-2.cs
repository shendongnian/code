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
            var peopleList = objList.PersonList;
            foreach(var person in peopleList)
            {
                var personArrayList = person.ToArray();
                foreach(var individual in personArrayList)
                {
                    string name = individual.Name;
                    int age = individual.Age;
                }
            }
